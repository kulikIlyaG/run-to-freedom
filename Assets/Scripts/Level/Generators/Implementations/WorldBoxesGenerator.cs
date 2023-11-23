using System.Collections.Generic;
using System.Linq;
using Level.Biomes.Data;
using Level.World;
using Level.World.Data;
using UnityEngine;
using Zenject;

namespace Level.Generators
{
    public abstract class WorldBoxesGenerator<TBoxImplementation, TBoxInterface> : IWorldBoxesGenerator
        where TBoxInterface : IWorldBoxView
        where TBoxImplementation : TBoxInterface
    {
        protected readonly DiContainer _container = null;
        private readonly IWorldDefinition _worldDefinition;
        private readonly Vector2 _startAnchor;
        private readonly Transform _parent;
        
        private List<TBoxInterface> _boxInstances = new(20);

        protected IBiomeDefinition _biome;
        private int _biomeBoxIndex;

        protected WorldBoxesGenerator(DiContainer container, IWorldDefinition worldDefinition, Vector2 startAnchor, Transform parent)
        {
            _container = container;
            _worldDefinition = worldDefinition;
            _startAnchor = startAnchor;
        }
        
        
        protected abstract TBoxInterface CreateInstance(TBoxImplementation prefab, Transform parent);
        protected abstract TBoxImplementation GetBoxPrefabByIndex(int index);
        protected abstract int GetStartBoxesCount();

        public void UpdateGeneration(IWorldRunner runner)
        {
            if (_boxInstances.Count == 0)
            {
                CreateFirstBoxes();
            }
            else
            {
                ValidateBoxesBehind(runner);
                ValidateBoxesInFront(runner.FrontVisionPoint.x);
            }
        }

        private void ValidateBoxesBehind(IWorldRunner runner)
        {
            var notVisibleBoxes = new List<TBoxInterface>(_boxInstances.Count);

            foreach (TBoxInterface box in _boxInstances)
            {
                if(!box.IsVisible(runner))
                    notVisibleBoxes.Add(box);
            }

            foreach (TBoxInterface box in notVisibleBoxes)
            {
                _boxInstances.Remove(box);
                box.DestroyInstance();
            }
        }

        private void ValidateBoxesInFront(float frontDistance)
        {
            var latestBox = _boxInstances.Last();
            if (latestBox.StartAnchor.x < frontDistance)
            {
                AddFrontBoxAt(latestBox.EndAnchor, frontDistance);
            }
        }

        private void AddFrontBoxAt(Vector2 anchorPoint, float distance)
        {
            var updatedBiome = _worldDefinition.GetBiomeByDistance(distance);
            
            if (updatedBiome != _biome)
            {
                _biome = updatedBiome;
                _biomeBoxIndex = 0;
            }
            
            CreateBoxInstance(GetBoxPrefabByIndex(_biomeBoxIndex), anchorPoint);
            _biomeBoxIndex++;
        }

        private void CreateFirstBoxes()
        {
            _biome = _worldDefinition.GetBiomeByDistance(0f);
            
            Vector2 anchorPosition = _startAnchor;
            int startBoxesCount = GetStartBoxesCount();
            for (int index = 0; index < startBoxesCount; index++)
            {
                var prefab = GetBoxPrefabByIndex(index);
                var instance = CreateBoxInstance(prefab, anchorPosition);
                anchorPosition = instance.EndAnchor;    
            }

            _biomeBoxIndex += startBoxesCount;
        }
        
        private TBoxInterface CreateBoxInstance(TBoxImplementation prefab, Vector2 point)
        {
            var instance = CreateInstance(prefab, _parent);
            instance.Name = prefab.Name;
            instance.SetPositionStartAnchor(point);
            _boxInstances.Add(instance);
            return instance;
        }
    }
}
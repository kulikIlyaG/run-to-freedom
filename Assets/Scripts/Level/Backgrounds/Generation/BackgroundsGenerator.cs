using System.Collections.Generic;
using System.Linq;
using Level.Backgrounds.Components;
using Level.Biomes.Data;
using Level.Generators;
using Level.World;
using Level.World.Data;
using UnityEngine;
using Zenject;

namespace Level.Backgrounds.Generation
{
    public class BackgroundsGenerator : WorldBoxesGenerator<BackgroundComponent, IBackgroundView>, IBackgroundsGenerator
    {
        private const int START_BACKGROUNDS_COUNT = 2;
        
        public BackgroundsGenerator(DiContainer container, IWorldDefinition worldDefinition, Vector2 startAnchor, Transform parent)
            : base(container, worldDefinition, startAnchor, parent)
        {
        }

        protected override IBackgroundView CreateInstance(BackgroundComponent prefab, Transform parent)
        {
            return _container.InstantiatePrefabForComponent<BackgroundComponent>(prefab, Vector3.zero, Quaternion.identity, parent);
        }

        protected override BackgroundComponent GetBoxPrefabByIndex(int index)
        {
            return _biome.GetBackgroundByIndex(index);
        }

        protected override int GetStartBoxesCount()
        {
            return START_BACKGROUNDS_COUNT;
        }
    }
}
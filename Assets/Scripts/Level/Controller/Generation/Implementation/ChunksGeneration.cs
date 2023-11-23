using Level.Chunks;
using Level.Chunks.Components;
using Level.Generators;
using Level.World.Data;
using UnityEngine;
using Zenject;

namespace Level.Controller.Generation
{
    public class ChunksGeneration : WorldBoxesGenerator<ChunkComponent, IChunkView>, IChunksGenerator
    {
        private const int START_CHUNKS_COUNT = 3;
        
        public ChunksGeneration(DiContainer container, IWorldDefinition worldDefinition, Vector2 startAnchor, Transform parent)
            : base(container, worldDefinition, startAnchor, parent)
        {
        }

        protected override IChunkView CreateInstance(ChunkComponent prefab, Transform parent)
        {
            return _container.InstantiatePrefabForComponent<ChunkComponent>(prefab, Vector3.zero, Quaternion.identity, parent);
        }

        protected override ChunkComponent GetBoxPrefabByIndex(int index)
        {
            return _biome.GetChunkByIndex(index);
        }

        protected override int GetStartBoxesCount()
        {
            return START_CHUNKS_COUNT;
        }
    }
}
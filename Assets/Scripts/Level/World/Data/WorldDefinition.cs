using System;
using Level.Biomes.Data;
using Level.Chunks.Components;
using UnityEngine;

namespace Level.World.Data
{
    [CreateAssetMenu(fileName = "World", menuName = "Level/World Definition")]
    public class WorldDefinition : ScriptableObject, IWorldDefinition
    {
        [Serializable]
        private class Biome
        {
            [SerializeField] private BiomeDefinition _biome;
            [SerializeField] private float _length;

            public BiomeDefinition Definition => _biome;
            public float Length => _length;
        }

        [SerializeField] private Biome[] _biomes;

        public IBiomeDefinition GetBiomeByDistance(float distance)
        {
            if (_biomes.Length > 1)
            {
                float length = 0f;
                for (int index = 0; index < _biomes.Length; index++)
                {
                    length += _biomes[index].Length;
                    if (distance < length)
                    {
                        return _biomes[index].Definition;
                    }
                }
            }

            return _biomes[0].Definition;
        }

        public ChunkComponent[] GetStartChunks(int count)
        {
            var biome = GetBiomeByDistance(0f);
            
            ChunkComponent[] result = new ChunkComponent[count];
            
            for (int index = 0; index < count; index++)
            {
                result[index] = biome.GetChunkByIndex(index);
            }

            return result;
        }
    }
}
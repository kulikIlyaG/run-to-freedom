using System;
using System.Linq;
using Level.Backgrounds.Components;
using Level.Chunks.Components;
using Root.Systems.AudioAmbient;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level.Biomes.Data
{
    [CreateAssetMenu(fileName = "BiomeDefinition", menuName = "Level/Biome Definition")]
    public class BiomeDefinition : ScriptableObject, IBiomeDefinition
    {
        [Serializable]
        private class ChunksContainer
        {
            [SerializeField] private ChunkComponent[] _chunks;
            [SerializeField] private int activeIndexesRange = 1;

            public int ActiveIndexesRange => activeIndexesRange;

            public ChunkComponent GetRandom()
            {
                if (_chunks.Length == 1)
                    return _chunks[0];
                
                return _chunks[Random.Range(0, _chunks.Length)];
            }
        }
        
        [SerializeField] private ChunksContainer[] _chunksContainers;
        [SerializeField] private BackgroundComponent[] _backgrounds;
        [SerializeField] private AudioAmbientSO[] _audioAmbient;

        public ChunkComponent GetChunkByIndex(int index)
        {
            foreach (ChunksContainer container in _chunksContainers)
            {
                if (container.ActiveIndexesRange > index)
                    return container.GetRandom();
            }

            return _chunksContainers.Last().GetRandom();
        }

        public BackgroundComponent GetBackgroundByIndex(int index)
        {
            if (_backgrounds.Length > index)
                return _backgrounds[index];

            return _backgrounds[Random.Range(0, _backgrounds.Length)];
        }

        public IAudioAmbient[] GetAmbientAudio()
        {
            return _audioAmbient;
        }
    }
}
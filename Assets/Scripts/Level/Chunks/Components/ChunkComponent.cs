using Level.Generators.Components;
using UnityEngine;

namespace Level.Chunks.Components
{
    public class ChunkComponent : WorldBoxComponent, IChunkView
    {
        [SerializeField] private Transform _endAnchor;

        public override Vector2 StartAnchor => transform.position;
        public override Vector2 EndAnchor => _endAnchor.position;
    }
}
using System;
using UnityEngine;

namespace Characters.Ragdoll
{
    [Serializable]
    internal class RagdollParameters : IRagdollParameters
    {
        [SerializeField] private Vector2 _forceOnFallingByUpperHit;
        [SerializeField] private Vector2 _forceOnFallingByMiddleHit;
        [SerializeField] private Vector2 _forceOnFallingByLowerHit;

        public Vector2 ForceOnFallingByUpperHit => _forceOnFallingByUpperHit;
        public Vector2 ForceOnFallingByMiddleHit => _forceOnFallingByMiddleHit;
        public Vector2 ForceOnFallingByLowerHit=> _forceOnFallingByLowerHit;
    }
}
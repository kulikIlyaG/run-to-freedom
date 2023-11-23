using UnityEngine;

namespace Characters.Ragdoll
{
    public interface IRagdollParameters
    {
        Vector2 ForceOnFallingByUpperHit { get; }
        Vector2 ForceOnFallingByMiddleHit { get; }
        Vector2 ForceOnFallingByLowerHit { get; }
    }
}
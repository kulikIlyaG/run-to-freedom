using UnityEngine;

namespace Characters.Jump
{
    public interface IJumpingParameters
    {
        float MaxJumpHeight { get; }
        float AdditionalFallImpulse { get; }
        Vector2 Direction { get; }
        float Power { get; }
    }
}
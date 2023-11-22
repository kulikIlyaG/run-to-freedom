using UnityEngine;

namespace Characters.Physics
{
    public interface ICharacterPhysics
    {
        void SetVelocity(Vector2 value);
        void AddVelocity(Vector2 value);
        void SetDrag(float drag);
        void ResetDrag();
        Vector2 Velocity { get; }
        Vector2 Position { get; }
        float GravityScale { get; }
        void AddForce(Vector2 force);
        void SetPosition(Vector2 position);
        void SetGravity(float value);
    }
}
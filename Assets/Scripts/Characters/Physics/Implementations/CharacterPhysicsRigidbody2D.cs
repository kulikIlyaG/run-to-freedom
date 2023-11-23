using UnityEngine;

namespace Characters.Physics
{
    internal class CharacterPhysicsRigidbody2D : ICharacterPhysics 
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _defaultDrag;

        public CharacterPhysicsRigidbody2D(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
            _defaultDrag = _rigidbody.drag;
        }

        Vector2 ICharacterPhysics.Velocity => _rigidbody.velocity;
        Vector2 ICharacterPhysics.Position => _rigidbody.position;
        float ICharacterPhysics.GravityScale => _rigidbody.gravityScale;

        void ICharacterPhysics.AddForce(Vector2 force)
        {
            _rigidbody.AddForce(force);
        }

        void ICharacterPhysics.SetPosition(Vector2 position)
        {
            _rigidbody.transform.position = position;
        }

        void ICharacterPhysics.SetGravity(float value)
        {
            _rigidbody.gravityScale = value;
        }

        void ICharacterPhysics.SetVelocity(Vector2 value)
        {
            _rigidbody.velocity = value;
        }

        void ICharacterPhysics.AddVelocity(Vector2 value)
        {
            _rigidbody.velocity += value;
        }

        void ICharacterPhysics.ResetDrag()
        {
            _rigidbody.drag = _defaultDrag;
        }

        void ICharacterPhysics.SetDrag(float drag)
        {
            _rigidbody.drag = drag;
        }
    }
}
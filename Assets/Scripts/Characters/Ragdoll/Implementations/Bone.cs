using System;
using UnityEngine;

namespace Characters.Ragdoll
{
    [Serializable]
    internal class Bone
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _collider;

        public void EnablePhysics()
        {
            _rigidbody.simulated = true;
        }

        public void DisablePhysics()
        {
            _rigidbody.simulated = false;
        }

        public void AddForce(Vector2 force)
        {
            _rigidbody.AddForce(force);
        }
    }
}
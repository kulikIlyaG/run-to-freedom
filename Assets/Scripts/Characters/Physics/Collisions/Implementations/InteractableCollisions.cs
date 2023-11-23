using System;
using Components.Physics2DExtensions;
using UnityEngine;

namespace Characters.Physics
{
    internal class InteractiveCollisions : IInteractiveCollisions
    {
        private readonly Collision2DEvents _collision2DEvents;

        public InteractiveCollisions(Collision2DEvents collision2DEvents)
        {
            _collision2DEvents = collision2DEvents;
        }

        public event Action<CollisionInfo> OnCollision;
        
        private void OnCollisionEnter(Collision2D obj)
        {
            OnCollision?.Invoke(new CollisionInfo(obj));
        }

        public void Initialize()
        {
            _collision2DEvents.OnEnter += OnCollisionEnter;
        }

        public void Dispose()
        {
            _collision2DEvents.OnEnter -= OnCollisionEnter;
        }

    }
}
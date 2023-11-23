using Characters.Damage;
using UnityEngine;

namespace Characters.Physics
{
    internal class ObstaclesCollisionsDetector : IObstaclesCollisionsDetector
    {
        private static readonly string[] OBSTACLES_TAGS = {"Obstacle"};

        private readonly IInteractiveCollisions _interactiveCollisions;
        private readonly IDamageExecutor _damageExecutor;

        public ObstaclesCollisionsDetector(
            IInteractiveCollisions interactiveCollisions,
            IDamageExecutor damageExecutor)
        {
            _interactiveCollisions = interactiveCollisions;
            _damageExecutor = damageExecutor;
        }

        public void Initialize()
        {
            _interactiveCollisions.OnCollision += OnCollisionWithAny;
        }

        private void OnCollisionWithAny(CollisionInfo info)
        {
            if (IsMyTagsRange(info.Tag))
            {
                Vector2 contactPoint = info.GetAverageContactPoint();
                if (_damageExecutor.IsInHitBox(contactPoint.y))
                {
                    _damageExecutor.TakeDamageAtPoint(new DamageInfo(contactPoint));
                }
            }
        }

        private bool IsMyTagsRange(string tag)
        {
            foreach (string myTag in OBSTACLES_TAGS)
            {
                if (tag.Equals(myTag))
                    return true;
            }

            return false;
        }

        public void Dispose()
        {
            _interactiveCollisions.OnCollision -= OnCollisionWithAny;
        }
    }
}
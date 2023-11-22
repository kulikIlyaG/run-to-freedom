using UnityEngine;

namespace Characters.Physics
{
    public class HitBoxColliderController : IHitBoxCollider
    {
        private readonly Collider2D _hitBoxCollider;

        public HitBoxColliderController(Collider2D hitBoxCollider)
        {
            _hitBoxCollider = hitBoxCollider;
        }

        public void ActivateHitBox()
        {
            _hitBoxCollider.enabled = true;
        }

        public void DeactivateHitBox()
        {
            _hitBoxCollider.enabled = false;
        }
    }
}
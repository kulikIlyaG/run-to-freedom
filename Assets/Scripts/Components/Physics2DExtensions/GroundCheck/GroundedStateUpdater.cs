using System;
using UnityEngine;

namespace Components.Physics2DExtensions
{
    public class GroundedStateUpdater : MonoBehaviour, IGroundCheck
    {
        [SerializeField] private float _minDistanceToGround = 0.1f;
        [SerializeField] private float _verticalOffsetRaycastsOrigin = 1f;

        [SerializeField] private LayerMask _groundLayers;

        private Collider2D _currentGround;

        bool IGroundCheck.IsGrounded => _currentGround != null;
        public event Action<bool> OnIsGroundedChanged;

        private void FixedUpdate()
        {
            ThrowRaycasts();
        }

        private void ThrowRaycasts()
        {
            Vector2 rayOrigin = (Vector2) transform.position + Vector2.up * _verticalOffsetRaycastsOrigin;

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, -Vector2.up, _minDistanceToGround, _groundLayers);
            Collider2D hitCollider = hit.collider;

            if (_currentGround == null && hit.collider != null)
            {
                OnGrounded(hitCollider);
            }
            else if (_currentGround != null && hitCollider == null)
            {
                OnUngrounded();
            }
        }

        private void OnGrounded(Collider2D groundCollider)
        {
            _currentGround = groundCollider;
            OnIsGroundedChanged?.Invoke(true);
        }

        private void OnUngrounded()
        {
            _currentGround = null;
            OnIsGroundedChanged?.Invoke(false);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            Vector3 origin = transform.position + Vector3.up * _verticalOffsetRaycastsOrigin;
            Vector3 targetPoint = origin + -Vector3.up * _minDistanceToGround;
            Gizmos.DrawLine(origin, targetPoint);
        }
    }
}
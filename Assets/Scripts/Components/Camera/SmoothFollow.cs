using UnityEngine;

namespace Components.Camera
{
    public class SmoothFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _speed = 1f;

        private void Update()
        {
            Vector3 followPoint = GetFollowPoint();
            
            transform.position = Vector3.Lerp(transform.position, followPoint, _speed * Time.deltaTime);
        }


        private Vector3 GetFollowPoint()
        {
            return _target.transform.position - _offset;
        }

        private void OnDrawGizmos()
        {
            if (_target != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(GetFollowPoint(), 0.25f);
            }
        }
    }
}
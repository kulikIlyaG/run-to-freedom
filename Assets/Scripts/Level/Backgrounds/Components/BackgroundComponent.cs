using Level.Generators.Components;
using Level.World;
using Root.Systems.CamerasSystem;
using UnityEngine;
using Zenject;

namespace Level.Backgrounds.Components
{
    public class BackgroundComponent : WorldBoxComponent, IBackgroundView
    {
        [SerializeField] private Bounds _bounds;
        [SerializeField] private Renderer[] _rendererElements;
        [SerializeField] private Transform _latestVisiblePoint;

        [Inject] private ICamerasSystem _camerasSystem;
        
        public override Vector2 StartAnchor => FlatBoundsCenter + -Vector3.right * (_bounds.size.x / 2f);
        public override Vector2 EndAnchor => FlatBoundsCenter + Vector3.right * (_bounds.size.x / 2f);
        private Vector3 FlatBoundsCenter => transform.TransformPoint(new Vector3(_bounds.center.x, 0f, _bounds.center.z));

        public override void SetPositionStartAnchor(Vector2 point)
        {
            float differenceOriginBetweenBounds = transform.position.x - FlatBoundsCenter.x + _bounds.size.x / 2f;
            transform.position = point + Vector2.right * differenceOriginBetweenBounds;
        }

        public override bool IsVisible(IWorldRunner _runner)
        {
            if (EndAnchor.x < _runner.BehindVisionPoint.x)
                return _camerasSystem.IsVisiblePoint(_latestVisiblePoint.transform.position);

            return true;
        }

        private void OnValidate()
        {
            ValidateBounds();
        }

        [ContextMenu("ValidateBounds")]
        private void ValidateBounds()
        {
            var childRenderers = transform.GetComponentsInChildren<Renderer>();
            _rendererElements = childRenderers;

            _bounds = new Bounds(transform.position, Vector3.zero);
            if (_rendererElements.Length > 0)
            {
                foreach (Renderer element in _rendererElements)
                {
                    _bounds.Encapsulate(element.bounds);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(transform.TransformPoint(_bounds.center), _bounds.size);

            Vector2 startPoint = StartAnchor;
            Vector2 endPoint = EndAnchor;
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(startPoint, endPoint);
            
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(startPoint, 5f);
            
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(endPoint, 5f);
        }
    }
}
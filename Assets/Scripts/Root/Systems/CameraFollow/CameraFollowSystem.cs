using PlayerLogic;
using PlayerLogic.Model;
using UnityEngine;
using Zenject;

namespace Root.Systems.CameraFollowSystem
{
    public class CameraFollowSystem : ICameraFollowSystem
    {
        [InjectOptional] private ICameraFollowTarget _target;
        [Inject] private readonly IPlayerControllerReadOnly _playerController;

        private readonly Camera _followCamera;

        private Vector3 _followOffset;
        private float _followSpeed;

        public CameraFollowSystem(Camera followCamera, Vector3 followOffset, float followSpeed)
        {
            _followCamera = followCamera;
            _followOffset = followOffset;
            _followSpeed = followSpeed;
        }

        public void Tick()
        {
            if(_target == null)
                return;
            
            Vector3 followPoint = (Vector3)_target.Position - _followOffset;
            
            _followCamera.transform.position = Vector3.Lerp(_followCamera.transform.position, followPoint, _followSpeed * Time.deltaTime);
        }

        private void SetFollowTarget(ICameraFollowTarget target)
        {
            _target = target;
        }

        public void Initialize()
        {
            _playerController.OnPlayerCreated += OnCreatedPlayer;
        }

        private void OnCreatedPlayer(IPlayerModel obj)
        {
            SetFollowTarget(obj);
        }

        public void Dispose()
        {
            _playerController.OnPlayerCreated -= OnCreatedPlayer;
        }
    }
}
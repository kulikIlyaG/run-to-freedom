using UnityEngine;
using Zenject;

namespace Root.Systems.CameraFollowSystem
{
    public class CameraFollowSystemInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        
        [SerializeField] private Vector3 _followOffset;
        [SerializeField] private float _followSpeed;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CameraFollowSystem>().FromNew().AsSingle()
                .WithArguments(_camera, _followOffset, _followSpeed).NonLazy();
        }
    }
}
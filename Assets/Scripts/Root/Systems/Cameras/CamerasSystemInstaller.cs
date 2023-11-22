using UnityEngine;
using Zenject;

namespace Root.Systems.CamerasSystem
{
    public class CamerasSystemInstaller : MonoInstaller
    {
        [SerializeField] private Camera _gameCamera;
        [SerializeField] private Camera _backgroundsCamera;
        
        public override void InstallBindings()
        {
            Container.Bind<ICamerasSystem>().To<CamerasSystem>().FromNew().AsSingle()
                .WithArguments(_gameCamera, _backgroundsCamera).NonLazy();
        }
    }
}
using Zenject;

namespace Root.Systems.FlyingModeSwitchSystem
{
    public class FlyingModeSwitchSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IFlyingModeSwitchSystem>().To<FlyingModeSwitchSystem>().FromNew().AsSingle()
                .NonLazy();
        }
    }
}
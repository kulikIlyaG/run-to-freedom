using Root.Services.Timers;
using Zenject;

namespace Root.Services.Timers
{
    public class TimersServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<TimersService>().FromNew().AsSingle().NonLazy();
        }
    }
}
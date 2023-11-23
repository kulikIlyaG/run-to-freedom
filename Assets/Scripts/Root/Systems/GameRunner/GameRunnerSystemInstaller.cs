using Zenject;

namespace Root.Systems.GameRunner
{
    public class GameRunnerSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameRunnerSystem>().FromNew().AsSingle().NonLazy();
        }
    }
}
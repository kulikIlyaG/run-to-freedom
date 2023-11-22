using Zenject;

namespace Root.Systems.SpeedModifier
{
    public class SpeedModifierSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISpeedModifierSystem>().To<SpeedModifierSystem>().AsSingle().NonLazy();
        }
    }
}
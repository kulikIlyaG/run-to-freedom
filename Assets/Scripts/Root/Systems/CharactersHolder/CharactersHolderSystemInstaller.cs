using Root.Systems.CharactersHolder;
using Zenject;

namespace Root.Systems.CharactersHolder
{
    public class CharactersHolderSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CharactersHolderSystem>().FromNew().AsSingle().NonLazy();
        }
    }
}
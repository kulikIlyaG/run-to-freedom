#if UNITY_EDITOR
using Root.Systems.GamePlayInput.Keyboard;
#else
using Root.Systems.GamePlayInput.Touch;
#endif
using Zenject;

namespace Root.Systems.GamePlayInput
{
    public class GameInputSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<InputModel>().FromNew().AsSingle().NonLazy();

#if UNITY_EDITOR
            Container.BindInterfacesTo<GameplayKeyboardInputSystem>().FromNew().AsSingle().NonLazy();
#else
            Container.BindInterfacesTo<TouchScreenJoystick>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesTo<GameplayTouchInputSystem>().FromNew().AsSingle().NonLazy();
#endif
        }
    }
}
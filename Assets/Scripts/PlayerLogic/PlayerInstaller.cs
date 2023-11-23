using Characters.Flying;
using Characters.Flying.Wings;
using Characters.Installers;
using Root.Systems.AudioFX;
using PlayerLogic.Model;
using UnityEngine;
using Zenject;

namespace PlayerLogic
{
    public class PlayerInstaller : CharacterInstaller
    {
        private IPlayerModel _playerModel;

        [SerializeField] private GameObject _wingsRoot;
        [SerializeField] private Animator _wingsAnimator;
        [SerializeField] private WingsAnimationEvents _wingsAnimationEvents;
        [SerializeField] private AudioFXSO _wingsAudioFx;

        [Inject]
        private void Construct(IPlayerModel model)
        {
            _playerModel = model;
            _injectedCharacterModel = model;
        }

        public override void InstallBindings()
        {
            base.InstallBindings();
            BindingFlyingOnWings();
        }

        protected override void BindCharacterEntity()
        {
            Container.BindInterfacesAndSelfTo<Player>().FromNew().AsSingle().WithArguments(_playerModel).NonLazy();
        }

        private void BindingFlyingOnWings()
        {
            Container.Bind<IWingsAnimationEvents>().To<WingsAnimationEvents>().FromInstance(_wingsAnimationEvents)
                .AsSingle().NonLazy();
            Container.Bind<IWingsAnimation>().To<WingsAnimationByAnimator>().FromNew().AsSingle().WithArguments(_wingsRoot, _wingsAnimator).NonLazy();
            Container.BindInterfacesTo<WingsAudioFX>().FromNew().AsSingle().WithArguments(_wingsAudioFx).NonLazy();
            
            Container.BindInterfacesTo<FlyingParameters>().FromInstance(_playerModel.FlyingParameters).AsSingle().NonLazy();
            Container.BindInterfacesTo<CharacterFlyingOnWings>().FromNew().AsSingle().NonLazy();
        }
    }
}
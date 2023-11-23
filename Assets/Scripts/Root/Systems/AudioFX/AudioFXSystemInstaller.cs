using Root.Systems.AudioFX.Components;
using Root.Systems.AudioFX;
using UnityEngine;
using Zenject;

namespace Root.Systems.AudioFX
{
    public class AudioFXSystemInstaller : MonoInstaller
    {
        [SerializeField] private AudioFXRaiserComponent _raiserPrefab;
        [SerializeField] private Transform _parentForActiveRaisers;
        [SerializeField] private Transform _parentForInactiveRaisers;


        public override void InstallBindings()
        {
            Container.Bind<IAudioFXRaisersPool>().To<AudioFXRaisersPool>().FromNew().AsSingle()
                .WithArguments(AudioFXSystem.MAX_RAISER_INSTANCES_COUNT, _raiserPrefab, _parentForActiveRaisers, _parentForInactiveRaisers).NonLazy();
            Container.Bind<IAudioFXSystem>().To<AudioFXSystem>().FromNew().AsSingle().NonLazy();
        }
    }
}
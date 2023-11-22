using Root.Systems.AudioAmbient.Components;
using Root.Systems.AudioAmbient;
using UnityEngine;
using Zenject;

namespace Root.Systems.AudioAmbient
{
    public class AudioAmbientSystemInstaller : MonoInstaller
    {
        [SerializeField] private AudioAmbientRaiserComponent _raiserPrefab;
        [SerializeField] private Transform _parentForActiveRaisers;
        [SerializeField] private Transform _parentForInactiveRaisers;
        
        public override void InstallBindings()
        {
            Container.Bind<IAudioAmbientRaisersPool>().To<AudioAmbientRaisersPool>().FromNew().AsSingle()
                .WithArguments(AudioAmbientSystem.MAX_RAISER_INSTANCES_COUNT, _raiserPrefab, _parentForActiveRaisers, _parentForInactiveRaisers).NonLazy();
            Container.Bind<IAudioAmbientSystem>().To<AudioAmbientSystem>().FromNew().AsSingle()
                .NonLazy();
        }
    }
}
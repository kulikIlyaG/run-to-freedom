using Root.Audio;
using Root.Systems.AudioFX.Components;
using UnityEngine;
using Zenject;

namespace Root.Systems.AudioFX
{
    public class AudioFXRaisersPool : AudioRaisersPool<AudioFXRaiserComponent>, IAudioFXRaisersPool
    {
        public AudioFXRaisersPool(int countMaxRaisersInactiveInstances, DiContainer container, AudioFXRaiserComponent raiserPrefab, Transform activeRaisersParent, Transform inactiveRaisersParent) : base(countMaxRaisersInactiveInstances, container, raiserPrefab, activeRaisersParent, inactiveRaisersParent)
        {
        }
    }
}
using Root.Audio;
using Root.Systems.AudioAmbient.Components;
using UnityEngine;
using Zenject;

namespace Root.Systems.AudioAmbient
{
    public class AudioAmbientRaisersPool : AudioRaisersPool<AudioAmbientRaiserComponent>, IAudioAmbientRaisersPool
    {
        public AudioAmbientRaisersPool(int countMaxRaisersInactiveInstances, DiContainer container, AudioAmbientRaiserComponent raiserPrefab, Transform activeRaisersParent, Transform inactiveRaisersParent) : base(countMaxRaisersInactiveInstances, container, raiserPrefab, activeRaisersParent, inactiveRaisersParent)
        {
        }
    }
}
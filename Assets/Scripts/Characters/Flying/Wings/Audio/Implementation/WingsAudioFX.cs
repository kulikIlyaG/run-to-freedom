using Characters.Flying.Wings;
using Root.Systems.AudioFX;
using UnityEngine;

namespace Characters.Flying.Wings
{
    public class WingsAudioFX : IWingsAudioFX
    {
        private readonly IAudioFXSystem _audioSystem;
        private readonly IAudioFX _swingFx;

        private readonly IWingsAnimationEvents _wingsAnimationEvents;

        public WingsAudioFX(IAudioFXSystem audioSystem, IAudioFX swingFx, IWingsAnimationEvents wingsAnimationEvents)
        {
            _audioSystem = audioSystem;
            _swingFx = swingFx;
            _wingsAnimationEvents = wingsAnimationEvents;
        }


        public void Initialize()
        {
            _wingsAnimationEvents.OnOpenedWings += OnSwing;
            _wingsAnimationEvents.OnClosedWings += OnSwing;
            _wingsAnimationEvents.OnSwing += OnSwing;
        }

        private void OnSwing()
        {
            _audioSystem.PlayAsync(_swingFx);
        }

        public void Dispose()
        {
            _wingsAnimationEvents.OnOpenedWings -= OnSwing;
            _wingsAnimationEvents.OnClosedWings -= OnSwing;
            _wingsAnimationEvents.OnSwing -= OnSwing;
        }
    }
}
using Characters.Animation;
using Root.Systems.AudioFX;

namespace Characters.Jump
{
    public class JumpingAudioFx : IJumpingAudioFX
    {
        private readonly IAudioFXSystem _audioFXSystem;
        private readonly IAudioFX _jumpingFx;
        private readonly IAudioFX _landingFx;

        private readonly ICharacterAnimationEvents _animationEvents;

        public JumpingAudioFx(IAudioFXSystem audioFXSystem, IAudioFX jumpingFx, IAudioFX landingFx, ICharacterAnimationEvents animationEvents)
        {
            _audioFXSystem = audioFXSystem;
            _jumpingFx = jumpingFx;
            _landingFx = landingFx;
            _animationEvents = animationEvents;
        }

        public void Initialize()
        {
            _animationEvents.OnPushGroundWhenJumping += OnJumping;
            _animationEvents.OnFirstTouchOnLanding += OnLanding;
        }

        private void OnJumping()
        {
            _audioFXSystem.PlayAsync(_jumpingFx);
        }

        private void OnLanding()
        {
            _audioFXSystem.PlayAsync(_landingFx);
        }

        public void Dispose()
        {
            _animationEvents.OnPushGroundWhenJumping -= OnJumping;
            _animationEvents.OnFirstTouchOnLanding -= OnLanding;
        }
    }
}
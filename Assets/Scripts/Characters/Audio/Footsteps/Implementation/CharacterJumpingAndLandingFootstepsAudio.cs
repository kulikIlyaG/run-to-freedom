using Characters.Animation;
using Root.Systems.AudioFX;

namespace Characters.Audio
{
    public class CharacterJumpingAndLandingFootstepsAudio : ICharacterJumpingAndLandingFootstepsAudio
    {
        private readonly IAudioFXSystem _audioFXSystem;
        private readonly IFootstepsAudioClipsContainer _clips;
        private readonly ICharacterAnimationEvents _animationEvents;

        public CharacterJumpingAndLandingFootstepsAudio(IAudioFXSystem audioFXSystem, IFootstepsAudioClipsContainer clips, ICharacterAnimationEvents animationEvents)
        {
            _audioFXSystem = audioFXSystem;
            _clips = clips;
            _animationEvents = animationEvents;
        }

        public void Initialize()
        {
            _animationEvents.OnPreparingToJump += OnJumping;
            _animationEvents.OnFirstTouchOnLanding += OnLanding;
        }

        private void OnLanding()
        {
            PlayFX(_clips.PeakLandingFootstepFx());
        }

        private void PlayFX(IAudioFX fx)
        {
            _audioFXSystem.PlayAsync(fx);
        }

        private void OnJumping()
        {
            PlayFX(_clips.PeakJumpingFootstepFx());
        }

        public void Dispose()
        {
            _animationEvents.OnPreparingToJump -= OnJumping;
            _animationEvents.OnFirstTouchOnLanding -= OnLanding;
        }
    }
}
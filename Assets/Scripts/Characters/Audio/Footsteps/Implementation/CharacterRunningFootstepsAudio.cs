using Characters.Animation;
using Root.Systems.AudioFX;

namespace Characters.Audio
{
    public class CharacterRunningFootstepsAudio : ICharacterRunningFootstepsAudio
    {
        private readonly ICharacterAnimationEvents _animationEvents;
        private readonly IFootstepsAudioClipsContainer _clips;
        private readonly IAudioFXSystem _audioFXSystem;

        public CharacterRunningFootstepsAudio(
            ICharacterAnimationEvents animationEvents,
            IFootstepsAudioClipsContainer clips,
            IAudioFXSystem audioFXSystem)
        {
            _animationEvents = animationEvents;
            _clips = clips;
            _audioFXSystem = audioFXSystem;
        }

        public void Initialize()
        {
            _animationEvents.OnLeftFootTouchTheGround += OnFootTouchGround;
            _animationEvents.OnRightFootTouchTheGround += OnFootTouchGround;
        }

        private void OnFootTouchGround()
        {
            _audioFXSystem.PlayAsync(_clips.PeakRegularFootstepFx());
        }

        public void Dispose()
        {
            _animationEvents.OnLeftFootTouchTheGround -= OnFootTouchGround;
            _animationEvents.OnRightFootTouchTheGround -= OnFootTouchGround;
        }
    }
}
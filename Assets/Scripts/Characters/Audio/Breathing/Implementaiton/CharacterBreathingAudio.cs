using Characters.Movement;
using Characters.Stats;
using Root.Systems.AudioFX;

namespace Characters.Audio
{
    public class CharacterBreathingAudio : ICharacterBreathingAudio
    {
        private readonly IMovementParameters _movementParameters;
        private readonly IAudioFXSystem _audioFXSystem;
        private readonly IBreathingAudioFXContainer _breathingAudioFXContainer;
        private readonly IHealth _health;

        public CharacterBreathingAudio(IMovementParameters movementParameters,
            IHealth health,
            IAudioFXSystem audioFXSystem,
            IBreathingAudioFXContainer breathingAudioFXContainer)
        {
            _health = health;
            _movementParameters = movementParameters;
            _audioFXSystem = audioFXSystem;
            _breathingAudioFXContainer = breathingAudioFXContainer;
        }


        public void Initialize()
        {
            _movementParameters.OnChangedSpeedLerp += OnChangedMovementSpeed;
            _health.OnChanged += OnCharacterHealthChanged;
        }

        private void OnCharacterHealthChanged(bool isAlive)
        {
            if (!isAlive)
            {
                _audioFXSystem.PlayAsync(_breathingAudioFXContainer.GetWeakBreathing());
            }
        }

        private void OnChangedMovementSpeed(bool isSpeedGrowUp)
        {
            if (isSpeedGrowUp)
            {
                RaiseBreathAudioRateDown();
            }
            else
            {
                RaiseBreathAudioRateUp();
            }
        }

        private void RaiseBreathAudioRateUp()
        {
            _audioFXSystem.PlayAsync(_breathingAudioFXContainer.GetBreathUpRate());
        }

        private void RaiseBreathAudioRateDown()
        {
            _audioFXSystem.PlayAsync(_breathingAudioFXContainer.GetBreathDownRate());
        }

        public void Dispose()
        {
            _movementParameters.OnChangedSpeedLerp -= OnChangedMovementSpeed;
            _health.OnChanged -= OnCharacterHealthChanged;
        }
    }
}
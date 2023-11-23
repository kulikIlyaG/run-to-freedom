using Root.Systems.AudioFX;

namespace Characters.Audio
{
    public interface IBreathingAudioFXContainer
    {
        IAudioFX GetBreathUpRate();
        IAudioFX GetBreathDownRate();
        IAudioFX GetWeakBreathing();
    }
}
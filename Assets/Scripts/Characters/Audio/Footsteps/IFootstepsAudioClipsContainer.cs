using Root.Systems.AudioFX;

namespace Characters.Audio
{
    public interface IFootstepsAudioClipsContainer
    {
        IAudioFX PeakRegularFootstepFx();
        IAudioFX PeakJumpingFootstepFx();
        IAudioFX PeakLandingFootstepFx();
    }
}
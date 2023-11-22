using UnityEngine;

namespace Root.Systems.AudioFX
{
    public class AudioFX : IAudioFX
    {
        public float Volume { get; }
        public AudioClip Clip { get; }

        public AudioFX(AudioClip clip)
        {
            Clip = clip;
            Volume = 1f;
        }

        public AudioFX(AudioClip clip, float volume)
        {
            Clip = clip;
            Volume = volume;
        }
    }
}
using UnityEngine;

namespace Root.Audio
{
    public interface IAudioClipData
    {
        AudioClip Clip { get; }
        float Volume { get; }
    }
}
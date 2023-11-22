using Root.Audio;

namespace Root.Systems.AudioAmbient
{
    public interface IAudioAmbient : IAudioClipData
    {
        string Id { get; }
    }
}
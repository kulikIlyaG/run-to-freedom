using Level.Backgrounds.Components;
using Level.Chunks.Components;
using Root.Systems.AudioAmbient;

namespace Level.Biomes.Data
{
    public interface IBiomeDefinition
    {
        ChunkComponent GetChunkByIndex(int index);
        BackgroundComponent GetBackgroundByIndex(int index);
        IAudioAmbient[] GetAmbientAudio();
    }
}
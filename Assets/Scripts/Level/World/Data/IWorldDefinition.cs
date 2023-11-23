using Level.Biomes.Data;
using Level.Chunks.Components;

namespace Level.World.Data
{
    public interface IWorldDefinition
    {
        IBiomeDefinition GetBiomeByDistance(float distance);
    }
}
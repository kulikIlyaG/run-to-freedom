using Level.World;

namespace Level.Generators
{
    public interface IWorldBoxesGenerator
    {
        void UpdateGeneration(IWorldRunner runner);
    }
}
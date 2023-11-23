using Zenject;

namespace Root.Systems.GameRunner
{
    public interface IGameRunnerSystem : IInitializable, ITickable
    {
        void BeginGame();
    }
}
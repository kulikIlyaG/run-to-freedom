using Zenject;

namespace Root.Systems.GameRunner
{
    /// <summary>
    /// В конечном итоге эта система должны была находится в каком-то большом классе
    /// который бы контролировал процесс точки входа и дальнейшего развития ux
    /// Однако для работующего демо в нем небыло нужды
    /// </summary>
    public interface IGameRunnerSystem : IInitializable, ITickable
    {
        void BeginGame();
    }
}
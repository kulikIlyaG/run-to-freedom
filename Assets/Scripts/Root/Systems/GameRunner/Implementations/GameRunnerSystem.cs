using Level.Controller;
using PlayerLogic;

namespace Root.Systems.GameRunner
{
    public class GameRunnerSystem : IGameRunnerSystem
    {
        private readonly IPlayerController _playerController;
        private readonly ILevelController _levelController;
        
        public GameRunnerSystem(IPlayerController playerController, ILevelController levelController)
        {
            _playerController = playerController;
            _levelController = levelController;
        }

        public void Initialize()
        {
            _playerController.CreatePlayer();
        }

        public void Tick()
        {
            _levelController.UpdateLevel();
        }

        public void BeginGame()
        {
            _playerController.Begin();
        }
    }
}
namespace Root.Systems.GamePlayInput.Touch
{
    public class GameplayTouchInputSystem : IGamePlayInputSystem
    {
        private readonly IGameplayInputModel _model;
        private readonly IAxisUIControllerExecutor _axisUIController;

        public GameplayTouchInputSystem(IGameplayInputModel model, IAxisUIControllerExecutor axisUIController)
        {
            _model = model;
            _axisUIController = axisUIController;
        }
        
        public void Tick()
        {
            _model.SetVerticalAxis(_axisUIController.Axis.y);
        }
    }
}
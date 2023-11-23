using UnityEngine;

namespace Root.Systems.GamePlayInput.Keyboard
{
    public class GameplayKeyboardInputSystem : IGamePlayInputSystem
    {
        private readonly IGameplayInputModel _model;

        public GameplayKeyboardInputSystem(IGameplayInputModel model)
        {
            _model = model;
        }

        public void Tick()
        {
            _model.SetVerticalAxis(Input.GetAxis("Vertical"));
        }
    }
}
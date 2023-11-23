namespace Root.Systems.GamePlayInput
{
    public class InputModel : IGameplayInputModel
    {
        private float _verticalAxis = 0f;

        float IGameplayInputModelReadOnly.VerticalAxis => _verticalAxis;

        void IGameplayInputModel.SetVerticalAxis(float value)
        {
            _verticalAxis = value;
        }
    }
}
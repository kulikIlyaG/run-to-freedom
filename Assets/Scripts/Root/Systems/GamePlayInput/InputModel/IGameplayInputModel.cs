namespace Root.Systems.GamePlayInput
{
    public interface IGameplayInputModel : IGameplayInputModelReadOnly
    {
        void SetVerticalAxis(float value);
    }
}
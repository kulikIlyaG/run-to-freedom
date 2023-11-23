namespace PlayerLogic
{
    public interface IPlayerController : IPlayerControllerReadOnly
    {
        void CreatePlayer();
        void Begin();
    }
}
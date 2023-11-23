using Characters.Flying;
using Characters.Model;
using Level.World;
using Root.Systems.CameraFollowSystem;

namespace PlayerLogic.Model
{
    public interface IPlayerModel : ICharacterModel, IPlayerModelReadOnly, ICameraFollowTarget, IWorldRunner
    {
        IFlyingParameters FlyingParameters { get; }
        void BeginFlying();
        void EndFlying();
    }
}
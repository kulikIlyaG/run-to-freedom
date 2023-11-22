using PlayerLogic.Model;

namespace Root.Systems.FlyingModeSwitchSystem
{
    public interface IFlyingModeSwitchSystem
    {
        void EnableFlying(IPlayerModel target, float duration);
    }
}
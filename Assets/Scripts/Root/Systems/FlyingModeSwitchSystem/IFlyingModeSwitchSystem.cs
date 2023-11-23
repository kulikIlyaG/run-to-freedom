using PlayerLogic.Model;

namespace Root.Systems.FlyingModeSwitchSystem
{
    /// <summary>
    /// отвечает за буст полета
    /// </summary>
    public interface IFlyingModeSwitchSystem
    {
        void EnableFlying(IPlayerModel target, float duration);
    }
}
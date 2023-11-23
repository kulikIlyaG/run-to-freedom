using System;
using Root.Services.Timers;
using PlayerLogic.Model;

namespace Root.Systems.FlyingModeSwitchSystem
{
    public class FlyingModeSwitchSystem : IFlyingModeSwitchSystem
    {
        private readonly ITimersService _timersService;

        public FlyingModeSwitchSystem(ITimersService timersService)
        {
            _timersService = timersService;
        }

        void IFlyingModeSwitchSystem.EnableFlying(IPlayerModel target, float durationInSeconds)
        {
            target.BeginFlying();
            var timer = _timersService.AddTimer(DateTime.Now.AddSeconds(durationInSeconds));
            timer.OnComplete += (t) => target.EndFlying();
        }
    }
}
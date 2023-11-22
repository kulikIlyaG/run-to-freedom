using System;
using Characters.Movement;
using Root.Services.Timers;

namespace Root.Systems.SpeedModifier
{
    public class SpeedModifierSystem : ISpeedModifierSystem
    {
        private readonly ITimersService _timersService;

        public SpeedModifierSystem(ITimersService timersService)
        {
            _timersService = timersService;
        }

        public void Apply(ISpeedModifierData data, ISpeedParameters target)
        {
            float originValue = target.LerpValue;
            target.SetSpeedLerp(data.TargetValue);
            
            var timer = _timersService.AddTimer(DateTime.Now.AddSeconds(data.DurationInSeconds));
            
            timer.OnComplete += (t) =>
            {
                target.SetSpeedLerp(originValue);
            };
        }
    }
}
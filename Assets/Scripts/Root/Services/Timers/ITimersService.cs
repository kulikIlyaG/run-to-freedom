using System;
using Zenject;

namespace Root.Services.Timers
{
    public interface ITimersService : ITickable
    {
        bool TryGetTimer(long id, out Timer timer);
        Timer AddTimer(DateTime endTime);
        void StopTimer(long id);
        void StopTimer(Timer timer);
        void PauseTimer(long id, bool isPause);
        void PauseTimer(Timer timer, bool isPause);
    }
}
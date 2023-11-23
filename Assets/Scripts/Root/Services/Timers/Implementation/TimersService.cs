using System;
using System.Collections.Generic;

namespace Root.Services.Timers
{
    public sealed class TimersService : ITimersService
    {
        private readonly HashSet<long> _takenIds;
        private readonly List<Timer> _timers;
        private long _nextId;

        public TimersService()
        {
            _nextId = 0;
            _takenIds = new HashSet<long>();
            _timers = new List<Timer>();
        }
        

        public void Tick()
        {
            Timer timer;
            for (int i = _timers.Count - 1; i >= 0; i--)
            {
                timer = _timers[i];

                if (timer.IsPaused)
                {
                    continue;
                }

                timer.FrameUpdate();
                if (timer.IsFinished)
                {
                    StopTimer(timer);
                }
            }
        }

        Timer ITimersService.AddTimer(DateTime endTime)
        {
            long id;
            do
            {
                id = _nextId++;
            }
            while (_takenIds.Contains(id));
            _takenIds.Add(id);

            var timer = new Timer(id, endTime);
            _timers.Add(timer);
            return timer;
        }

        public bool TryGetTimer(long id, out Timer timer)
        {
            timer = _timers.Find(x => x.ID.Equals(id));
            if (timer == null)
            {
                return false;
            }
            return true;
        }

        public void StopTimer(long id)
        {
            if (!TryGetTimer(id, out var timer))
            {
                return;
            }

            StopTimer(timer);
        }

        public void StopTimer(Timer timer)
        {
            if (timer == null)
            {
                return;
            }

            _takenIds.Remove(timer.ID);
            _timers.Remove(timer);
        }

        public void PauseTimer(long id, bool isPause)
        {
            if (!TryGetTimer(id, out var timer))
            {
                return;
            }

            PauseTimer(timer, isPause);
        }

        public void PauseTimer(Timer timer, bool isPause)
        {
            timer?.SetPause(isPause);
        }
    }
}
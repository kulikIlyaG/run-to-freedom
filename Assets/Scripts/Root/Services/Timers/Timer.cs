using System;

namespace Root.Services.Timers
{
    public class Timer
    {
        private double _millisecondsLeft;
        private DateTime _pauseDateTime;

        public event Action<Timer> OnUpdate;
        public event Action<Timer> OnComplete;
        
        public Timer(long id, DateTime endTime)
        {
            ID = id;
            StartTime = DateTime.Now;;
            EndTime = endTime;
            IsFinished = false;
            _millisecondsLeft = (EndTime - StartTime).TotalMilliseconds;
        }
        
        
        public long ID { get; private set; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; private set; }
        public TimeSpan RemainTime => TimeSpan.FromMilliseconds(_millisecondsLeft);
        public bool IsFinished { get; private set; }
        public bool IsPaused { get; private set; }
        
        
        public void FrameUpdate()
        {
            _millisecondsLeft = (EndTime - DateTime.Now).TotalMilliseconds;
            OnUpdate?.Invoke(this);
            if (_millisecondsLeft <= 0)
            {
                IsFinished = true;
                OnComplete?.Invoke(this);
            }
        }

        public void SetPause(bool isPause)
        {
            if (IsPaused && isPause)
            {
                return;
            }

            if (!IsPaused && !isPause)
            {
                return;
            }

            if (isPause)
            {
                _pauseDateTime = DateTime.Now;
            }
            else
            {
                var skippedMilliseconds = (DateTime.Now - _pauseDateTime).TotalMilliseconds;
                EndTime += TimeSpan.FromMilliseconds(skippedMilliseconds);
                _pauseDateTime = DateTime.MinValue;
            }
            IsPaused = isPause;
        }
    }
}
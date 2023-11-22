using System;

namespace Characters.Stats
{
    public interface IHealthReadOnly
    {
        bool IsAlive { get; }
        event Action<bool> OnChanged;
    }
}
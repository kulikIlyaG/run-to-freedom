using System;

namespace Characters.Stats
{
    internal class Health : IHealth
    {
        public bool IsAlive { private set;  get; }
        
        public event Action<bool> OnChanged;
        
        public void Set(float value)
        {
            bool newValue = value > 0f;
            
            if (newValue != IsAlive)
            {
                IsAlive = newValue;
                OnChanged?.Invoke(IsAlive);
            }
        }
    }
}
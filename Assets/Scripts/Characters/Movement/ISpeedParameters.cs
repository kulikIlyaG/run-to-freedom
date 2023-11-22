using System;

namespace Characters.Movement
{
    public interface ISpeedParameters
    {
        event Action<bool> OnChangedSpeedLerp;
        float LerpValue { get; }
        void SetSpeedLerp(float value, float duration = 0.35f);
    }
}
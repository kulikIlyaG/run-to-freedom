using Characters.Movement;

namespace Root.Systems.SpeedModifier
{
    /// <summary>
    /// отвечает за бафф и дебаф скорости
    /// </summary>
    public interface ISpeedModifierSystem
    {
        void Apply(ISpeedModifierData data, ISpeedParameters target);
    }
}
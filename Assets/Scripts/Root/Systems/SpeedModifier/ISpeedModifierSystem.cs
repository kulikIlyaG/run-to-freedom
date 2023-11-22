using Characters.Movement;

namespace Root.Systems.SpeedModifier
{
    public interface ISpeedModifierSystem
    {
        void Apply(ISpeedModifierData data, ISpeedParameters target);
    }
}
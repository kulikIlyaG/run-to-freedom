namespace Characters.Movement
{
    public interface IMovementParameters : ISpeedParameters
    {
        float GetSpeed();
        float GetNormalizedSpeed(float source);
        void SetSpeedMultiplier(float value);
        float FallMultiplier { get; }
    }
}
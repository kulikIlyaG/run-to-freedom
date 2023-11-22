namespace Root.Systems.SpeedModifier
{
    public interface ISpeedModifierData
    {
        float TargetValue { get; }
        float DurationInSeconds { get; }
    }
}
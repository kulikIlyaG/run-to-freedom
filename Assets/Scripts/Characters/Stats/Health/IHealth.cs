namespace Characters.Stats
{
    public interface IHealth : IHealthReadOnly
    {
        void Set(float value);
    }
}
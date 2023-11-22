namespace Characters.Damage
{
    public interface IDamageExecutor
    {
        bool IsInHitBox(float yPotentialHitPoint);
        void TakeDamageAtPoint(DamageInfo info);
    }
}
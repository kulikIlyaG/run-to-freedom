using Characters.Animation;

namespace Characters.Damage
{
    internal class DamageExecutor : IDamageExecutor
    {
        private readonly HitBoxParameters _hitBox;
        private readonly ICharacterAnimation _animation;

        public DamageExecutor(HitBoxParameters hitBox, ICharacterAnimation animation)
        {
            _hitBox = hitBox;
            _animation = animation;
        }

        public bool IsInHitBox(float yPotentialHitPoint)
        {
            return _hitBox.IsInHitBox(yPotentialHitPoint);
        }

        public void TakeDamageAtPoint(DamageInfo info)
        {
            _animation.PlayFallingFromHit(_hitBox.GetHitLevel(info.HitPoint.y));
        }
    }
}
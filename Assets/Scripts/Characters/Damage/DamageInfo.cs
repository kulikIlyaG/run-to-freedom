using UnityEngine;

namespace Characters.Damage
{
    public class DamageInfo
    {
        public readonly Vector2 HitPoint;

        public DamageInfo(Vector2 hitPoint)
        {
            HitPoint = hitPoint;
        }
    }
}
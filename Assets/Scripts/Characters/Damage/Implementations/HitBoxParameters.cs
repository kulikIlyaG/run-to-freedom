using UnityEngine;

namespace Characters.Damage
{
    internal struct HitBoxParameters
    {
        private readonly float _height;
        private readonly float _noHitZonePercent;
        private readonly float _percentLegsHeight;
        private readonly float _percentBodyHeight;
        private readonly Transform _origin;

        public HitBoxParameters(float height, float noHitZonePercent, float percentLegsHeight, float percentBodyHeight, Transform origin)
        {
            _height = height;
            _noHitZonePercent = noHitZonePercent;
            _percentLegsHeight = percentLegsHeight;
            _percentBodyHeight = percentBodyHeight;
            _origin = origin;
        }

        public bool IsInHitBox(float yPotentialHitPoint)
        {
            return yPotentialHitPoint > _origin.position.y + _height * _noHitZonePercent;
        }

        public HitLevel GetHitLevel(float yHitPoint)
        {
            if (yHitPoint <= _origin.position.y + _height * _percentLegsHeight)
            {
                return HitLevel.Lower;
            }
            
            if (yHitPoint <= _origin.position.y + _height * _percentBodyHeight)
            {
                return HitLevel.Middle;
            }

            return HitLevel.Upper;
        }
    }
}
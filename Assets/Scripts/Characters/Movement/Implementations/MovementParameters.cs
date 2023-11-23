using System;
using DG.Tweening;
using UnityEngine;

namespace Characters.Movement
{
    [Serializable]
    public class MovementParameters : IMovementParameters
    {
        [SerializeField] private float _minSpeed = 5f;
        [SerializeField] private float _maxSpeed = 15f;
        [SerializeField] [Range(0f, 1f)] private float _speedLerp = 0.5f;

        [SerializeField] private float _fallMultiplier = 15f;
        
        private float _currentSpeed;

        private float _speedMultiplier = 1f;
        
        
        public event Action<bool> OnChangedSpeedLerp;
        
        public float FallMultiplier => _fallMultiplier;
        public float LerpValue => _speedLerp;

        public void SetSpeedLerp(float value, float duration = 0.35f)
        {
            bool isUp = value > _speedLerp;
            
            float targetValue = Mathf.Clamp01(value);
            
            if (duration > 0f)
            {
                DOTween.To(()=> _speedLerp, x=> _speedLerp = x, targetValue, duration).SetEase(Ease.Linear).SetAutoKill();
            }
            else
            {
                _speedLerp = targetValue;
            }

            OnChangedSpeedLerp?.Invoke(isUp);
        }

        public float GetSpeed()
        {
            _currentSpeed = Mathf.Lerp(_minSpeed, _maxSpeed, _speedLerp);
            return _currentSpeed * _speedMultiplier;
        }

        public float GetNormalizedSpeed(float source)
        {
            float maxValue = _maxSpeed - _minSpeed;
            float value = source - _minSpeed;
            return value / maxValue;
        }

        public void SetSpeedMultiplier(float value)
        {
            _speedMultiplier = value;
        }
    }
}
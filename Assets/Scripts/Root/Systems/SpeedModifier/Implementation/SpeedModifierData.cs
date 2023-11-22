using UnityEngine;

namespace Root.Systems.SpeedModifier
{
    [CreateAssetMenu(fileName = "Speed Modifier", menuName = "Modifiers/Speed")]
    public class SpeedModifierData : ScriptableObject, ISpeedModifierData
    {
        [SerializeField] [Range(0f, 1f)] private float _targetValue = 0.5f;
        [SerializeField] private float _durationInSeconds = 1f;
        
        public float TargetValue => _targetValue;
        public float DurationInSeconds => _durationInSeconds;
    }
}
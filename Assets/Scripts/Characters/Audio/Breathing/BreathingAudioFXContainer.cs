using Root.Systems.AudioFX;
using UnityEngine;

namespace Characters.Audio
{
    [CreateAssetMenu(fileName = "Breathing Footsteps", menuName = "Audio/FX/Breathing")]
    public class BreathingAudioFXContainer : ScriptableObject, IBreathingAudioFXContainer
    {
        [SerializeField] private AudioClip[] _clipsBreathUpRate;
        [SerializeField] private AudioClip[] _clipsBreathDownRate;
        [SerializeField] private AudioClip[] _clipsBreathWeakRate;

        private int _previouslyClipRateUpIndex;
        private int _previouslyClipRateDownIndex;
        private int _previouslyClipWeakRateIndex;
        
        IAudioFX IBreathingAudioFXContainer.GetBreathUpRate()
        {
            int index = _previouslyClipRateUpIndex;
            
            if (_clipsBreathUpRate.Length > 1)
            {
                while (index == _previouslyClipRateUpIndex)
                {
                    index = Random.Range(0, _clipsBreathUpRate.Length);
                }
            }
            
            return new AudioFX(_clipsBreathUpRate[index]);
        }

        IAudioFX IBreathingAudioFXContainer.GetBreathDownRate()
        {
            int index = _previouslyClipRateDownIndex;

            if (_clipsBreathDownRate.Length > 1)
            {
                while (index == _previouslyClipRateDownIndex)
                {
                    index = Random.Range(0, _clipsBreathDownRate.Length);
                }
            }
            
            return new AudioFX(_clipsBreathDownRate[index]);
        }

        IAudioFX IBreathingAudioFXContainer.GetWeakBreathing()
        {
            int index = _previouslyClipWeakRateIndex;

            if (_clipsBreathWeakRate.Length > 1)
            {
                while (index == _previouslyClipWeakRateIndex)
                {
                    index = Random.Range(0, _clipsBreathWeakRate.Length);
                }
            }

            return new AudioFX(_clipsBreathWeakRate[index]);
        }
    }
}
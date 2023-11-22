using Root.Systems.AudioFX;
using UnityEngine;

namespace Characters.Audio
{
    [CreateAssetMenu(fileName = "Audio Footsteps", menuName = "Audio/FX/Footsteps")]
    public class FootstepsAudioFxContainer : ScriptableObject, IFootstepsAudioClipsContainer
    {
        [SerializeField] private AudioClip[] _regularFootsteps;
        
        [SerializeField] private AudioClip[] _landingAndJumpingFx;

        private int previouslyRandomIndexForRegular;
        IAudioFX IFootstepsAudioClipsContainer.PeakRegularFootstepFx()
        {
            int index = previouslyRandomIndexForRegular;
            
            while (index == previouslyRandomIndexForRegular)
            {
                index = Random.Range(0, _regularFootsteps.Length);
            }

            previouslyRandomIndexForRegular = index;
            return new AudioFX(_regularFootsteps[index]);
        }

        IAudioFX IFootstepsAudioClipsContainer.PeakJumpingFootstepFx()
        {
            return PeakLandingOrJumpingFX();
        }

        IAudioFX IFootstepsAudioClipsContainer.PeakLandingFootstepFx()
        {
            return PeakLandingOrJumpingFX();
        }
        

        private int previouslyRandomIndexForJumpingAndLanding;
        private IAudioFX PeakLandingOrJumpingFX()
        {
            int index = previouslyRandomIndexForJumpingAndLanding;
            
            while (index == previouslyRandomIndexForJumpingAndLanding)
            {
                index = Random.Range(0, _landingAndJumpingFx.Length);
            }

            previouslyRandomIndexForJumpingAndLanding = index;
            return new AudioFX(_landingAndJumpingFx[index]);
        }
    }
}
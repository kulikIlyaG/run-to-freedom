using System;
using Characters.Animation;
using UnityEngine;

namespace Characters.Particles
{
    internal class CharacterParticles : ICharacterParticles
    {
        private readonly ICharacterAnimationEvents _animationEvents;
        
        private readonly TransformAnchoredParticle _leftFootGroundSplash;
        private readonly TransformAnchoredParticle _rightFootGroundSplash;

        public CharacterParticles(ICharacterAnimationEvents animationEvents, TransformAnchoredParticle leftFootGroundSplash, TransformAnchoredParticle rightFootGroundSplash)
        {
            _animationEvents = animationEvents;
            _leftFootGroundSplash = leftFootGroundSplash;
            _rightFootGroundSplash = rightFootGroundSplash;
        }

        public void Initialize()
        {
            _animationEvents.OnLeftFootTouchTheGround += RaiseLeftFootSplash;
            _animationEvents.OnRightFootTouchTheGround += RaiseRightFootSplash;
        }

        private void RaiseRightFootSplash()
        {
            _rightFootGroundSplash.Raise();
        }

        private void RaiseLeftFootSplash()
        {
            _leftFootGroundSplash.Raise();
        }

        public void Dispose()
        {
            _animationEvents.OnLeftFootTouchTheGround -= RaiseLeftFootSplash;
            _animationEvents.OnRightFootTouchTheGround -= RaiseRightFootSplash;
        }

        [Serializable]
        public class TransformAnchoredParticle
        {
            [SerializeField] private Transform _origin;
            [SerializeField] private ParticleSystem _particle;

            public void Raise()
            {
                if(_particle.isPlaying)
                    _particle.Stop();
                
                _particle.transform.position = _origin.position;
                _particle.Play();
            }
        }
    }
}
using System;
using UnityEngine;

namespace Characters.Animation
{
    internal class AnimatorEvents : MonoBehaviour, ICharacterAnimationEvents
    {
        public event Action OnPushGroundWhenJumping;
        public event Action OnPushGroundWhenSomersault;
        public event Action OnFirstTouchOnLanding;
        public event Action OnLandingFinished;
        public event Action OnPreparingToJump;
        public event Action OnLeftFootTouchTheGround;
        public event Action OnRightFootTouchTheGround;
        public event Action OnFinishedSomersault;
        public event Action OnFallingFromUpperHit;
        public event Action OnFallingFromMiddleHit;
        public event Action OnFallingFromLowerHit;
        public event Action OnBeginOpeningWings;
        public event Action OnBeginClosingWings;


        public void OnRaiseJumpForce()
        {
            OnPushGroundWhenJumping?.Invoke();
        }

        public void OnRaiseSomersaultForce()
        {
            OnPushGroundWhenSomersault?.Invoke();
        }

        public void OnFirstTouchWhenLanding()
        {
            OnFirstTouchOnLanding?.Invoke();
        }

        public void OnLandingCompleted()
        {
            OnLandingFinished?.Invoke();
        }

        public void OnPrepareToJump()
        {
            OnPreparingToJump?.Invoke();
        }

        public void OnLeftFootTouchGround()
        {
            OnLeftFootTouchTheGround?.Invoke();
        }
        
        public void OnRightFootTouchGround()
        {
            OnRightFootTouchTheGround?.Invoke();
        }

        public void OnBeginFallingFromUpperHitReaction()
        {
            OnFallingFromUpperHit?.Invoke();
        }

        public void OnBeginFallingFromMiddleHitReaction()
        {
            OnFallingFromMiddleHit?.Invoke();
        }

        public void OnBeginFallingFromLowerHitReaction()
        {
            OnFallingFromLowerHit?.Invoke();
        }
        
        public void OnStandUpAfterSomersault()
        {
            OnFinishedSomersault?.Invoke();
        }

        public void OnBeginOpenWings()
        {
            OnBeginOpeningWings?.Invoke();
        }

        public void OnBeginCloseWings()
        {
            OnBeginClosingWings?.Invoke();
        }
    }
}
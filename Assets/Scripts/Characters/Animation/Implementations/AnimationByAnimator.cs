using Characters.Damage;
using Components.Physics2DExtensions;
using UnityEngine;

namespace Characters.Animation
{
    internal class AnimationByAnimator : ICharacterAnimation
    {
        private readonly Animator _animator;
        private readonly IGroundCheck _groundCheck;



        public AnimationByAnimator(Animator animator,
            IGroundCheck groundCheck)
        {
            _animator = animator;
            _groundCheck = groundCheck;
        }

        public void Initialize()
        {
            _groundCheck.OnIsGroundedChanged += OnChangedGroundedState;
            
            SetGroundedBool(_groundCheck.IsGrounded);
        }

        public void Dispose()
        {
            _groundCheck.OnIsGroundedChanged -= OnChangedGroundedState;
        }

        void ICharacterAnimation.PlayJump()
        {
            RaiseJumpingTrigger();
        }

        void ICharacterAnimation.PlaySomersault()
        {
            RaiseSomersaultTrigger();
        }

        void ICharacterAnimation.UpdateHorizontalSpeed(float normalizeSpeed)
        {
            _animator.SetFloat(Keys.HORIZONTAL_SPEED_PARAMETER_KEY, normalizeSpeed);
        }

        void ICharacterAnimation.UpdateVerticalSpeed(float signSpeed)
        {
            _animator.SetFloat(Keys.VERTICAL_SPEED_PARAMETER_KEY, signSpeed);
        }

        void ICharacterAnimation.PlayFallingFromHit(HitLevel hitLevel)
        {
            switch (hitLevel)
            {
                case HitLevel.Upper:
                    PlayUpperHit();
                    break;
                case HitLevel.Middle:
                    PlayMiddleHit();
                    break;
                default:
                    PlayLowerHit();
                    break;
            }
        }

        void ICharacterAnimation.PlayFlying()
        {
            _animator.SetBool(Keys.FLYING_PARAMETER_KEY, true);
        }

        void ICharacterAnimation.PlayEndFlying()
        {
            _animator.SetBool(Keys.FLYING_PARAMETER_KEY, false);
        }

        void ICharacterAnimation.Disable()
        {
            _animator.enabled = false;
        }

        void ICharacterAnimation.Enable()
        {
            _animator.enabled = true;
        }

        private void OnChangedGroundedState(bool isGrounded)
        {
            SetGroundedBool(isGrounded);
        }

        private void SetGroundedBool(bool isGrounded)
        {
            _animator.SetBool(Keys.GROUNDED_PARAMETER_KEY, isGrounded);
        }

        private void PlayLowerHit()
        {
            _animator.SetTrigger(Keys.LOWER_HIT_PARAMETER_KEY);
        }

        private void PlayMiddleHit()
        {
            _animator.SetTrigger(Keys.MIDDLE_HIT_PARAMETER_KEY);
        }

        private void PlayUpperHit()
        {
            _animator.SetTrigger(Keys.UPPER_HIT_PARAMETER_KEY);
        }

        private void RaiseJumpingTrigger()
        {
            _animator.SetTrigger(Keys.JUMPING_PARAMETER_KEY);
        }
        
        private void RaiseSomersaultTrigger()
        {
            _animator.SetTrigger(Keys.SOMERSAULT_PARAMETER_KEY);
        }
    }
}
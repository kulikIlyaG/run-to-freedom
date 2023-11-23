using Characters.Animation;
using Characters.Physics;
using UnityEngine;

namespace Characters.Jump
{
    internal class JumpingAddForce : IJumping
    {
        private readonly ICharacterAnimation _animation;
        private readonly ICharacterAnimationEvents _animationEvents;
        private readonly ICharacterPhysics _physics;

        private readonly IJumpAvailableChecker _jumpAvailable;

        private readonly IJumpingParameters _parameters;

        private Vector2 _jumpPosition;
        
        public JumpingAddForce(ICharacterPhysics physics,
            IJumpingParameters parameters,
            ICharacterAnimation animation,
            ICharacterAnimationEvents animationEvents,
            IJumpAvailableChecker jumpAvailable)
        {
            _animation = animation;
            _physics = physics;
            _parameters = parameters;
            _animationEvents = animationEvents;
            _jumpAvailable = jumpAvailable;
        }

        public bool IsJumping { private set; get; }
        
        public void Initialize()
        {
            _animationEvents.OnPushGroundWhenJumping += ReleaseJumpForce;
            _animationEvents.OnFirstTouchOnLanding += OnTouchGroundAfterJump;
        }

        public void Dispose()
        {
            _animationEvents.OnPushGroundWhenJumping -= ReleaseJumpForce;
            _animationEvents.OnFirstTouchOnLanding -= OnTouchGroundAfterJump;
        }
        

        public void FixedTick()
        {
            if (IsJumping)
            {
                float currentFlyDistance = _physics.Position.y - _jumpPosition.y;
                if (currentFlyDistance >= _parameters.MaxJumpHeight)
                {
                    _physics.ResetDrag();
                    _physics.AddForce(Vector2.down * _parameters.AdditionalFallImpulse);
                }
            }
        }

        public virtual void Jump()
        {
            if(IsJumping)
                return;
            if(!_jumpAvailable.ICanJump())
                return;
            
            IsJumping = true;
            _animation.PlayJump();
        }

        
        private void OnTouchGroundAfterJump()
        {
            IsJumping = false;
        }

        private void ReleaseJumpForce()
        {
            _jumpPosition = _physics.Position;
            
            _physics.SetVelocity(Vector2.zero);
            var force = _parameters.Direction * _parameters.Power;
            _physics.AddForce(force);
            _physics.SetDrag(1f);
        }
    }
}
using Characters.Animation;
using Characters.Physics;
using UnityEngine;

namespace Characters.Movement
{
    internal class CharacterMovement : VelocityMovement
    {
        private readonly ICharacterAnimation _animation;
        
        public CharacterMovement(ICharacterPhysics physics, IMovementParameters parameters, ICharacterAnimation animation, IMovementAvailableChecker moveAvailable) : base(physics, parameters, moveAvailable)
        {
            _animation = animation;
        }


        protected override void Move()
        {
            base.Move();
            
            _animation.UpdateHorizontalSpeed(_parameters.GetNormalizedSpeed(_physics.Velocity.x));
            _animation.UpdateVerticalSpeed(Mathf.Clamp(_physics.Velocity.y, -1f, 1f));
        }
    }
}
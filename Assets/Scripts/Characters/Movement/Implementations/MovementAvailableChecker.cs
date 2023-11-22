using Characters.Flying;
using Characters.Somersault;
using Components.Physics2DExtensions;
using Zenject;

namespace Characters.Movement
{
    public class MovementAvailableChecker : IMovementAvailableChecker
    {
        [Inject] private readonly IGroundCheck _groundCheck;
        [InjectOptional] private readonly ICharacterSomersault _somersault;
        [InjectOptional] private readonly IFlying _flying;
        
        public bool ICanMove()
        {
            return (_groundCheck.IsGrounded || _flying is {IsEnabled: true})
                   && _somersault is {IsSomersaultNow: false};
        }
    }
}
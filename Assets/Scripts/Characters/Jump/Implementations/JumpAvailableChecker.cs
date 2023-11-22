using Characters.Flying;
using Characters.Somersault;
using Components.Physics2DExtensions;
using Zenject;

namespace Characters.Jump
{
    public class JumpAvailableChecker : IJumpAvailableChecker
    {
        [Inject] private readonly IGroundCheck _groundCheck;

        [InjectOptional] private readonly ICharacterSomersault _somersault;
        [InjectOptional] private readonly IFlying _flying;


        bool IJumpAvailableChecker.ICanJump()
        {
            return _groundCheck.IsGrounded
                   && _somersault is {IsSomersaultNow: false}
                   && _flying is {IsEnabled: false};
        }
    }
}
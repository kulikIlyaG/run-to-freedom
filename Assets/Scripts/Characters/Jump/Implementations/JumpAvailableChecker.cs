using Characters.Flying;
using Characters.Somersault;
using Components.Physics2DExtensions;
using Zenject;

namespace Characters.Jump
{
    public class JumpAvailableChecker : IJumpAvailableChecker
    {
        private readonly DiContainer _container;
        private readonly IGroundCheck _groundCheck;

        public JumpAvailableChecker(DiContainer container, IGroundCheck groundCheck)
        {
            _container = container;
            _groundCheck = groundCheck;
        }

        bool IJumpAvailableChecker.ICanJump()
        {
            return _groundCheck.IsGrounded
                   && _container.Resolve<ICharacterSomersault>() is {IsSomersaultNow: false}
                   && _container.Resolve<IFlying>() is {IsEnabled: false};
        }
    }
}
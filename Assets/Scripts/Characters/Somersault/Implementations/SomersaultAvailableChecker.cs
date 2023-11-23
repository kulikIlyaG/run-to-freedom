using Characters.Flying;
using Characters.Jump;
using Components.Physics2DExtensions;
using Zenject;

namespace Characters.Somersault
{
    public class SomersaultAvailableChecker : ISomersaultAvailableChecker
    {
        private readonly DiContainer _container;
        private readonly IGroundCheck _groundCheck;

        public SomersaultAvailableChecker(DiContainer container, IGroundCheck groundCheck)
        {
            _container = container;
            _groundCheck = groundCheck;
        }

        bool ISomersaultAvailableChecker.ICanSomersault()
        {
            return _groundCheck.IsGrounded
                   && _container.Resolve<IFlying>() is {IsEnabled: false}
                   && _container.Resolve<IJumping>() is { IsJumping: false};
        }
    }
}
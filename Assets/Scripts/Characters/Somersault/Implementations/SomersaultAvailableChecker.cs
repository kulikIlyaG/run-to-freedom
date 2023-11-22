using Characters.Flying;
using Components.Physics2DExtensions;
using Zenject;

namespace Characters.Somersault
{
    public class SomersaultAvailableChecker : ISomersaultAvailableChecker
    {
        [Inject] private readonly IGroundCheck _groundCheck;

        [InjectOptional] private readonly IFlying _flying;
        
        bool ISomersaultAvailableChecker.ICanSomersault()
        {
            return _groundCheck.IsGrounded
                   && _flying is {IsEnabled: false};
        }
    }
}
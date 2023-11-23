using System;

namespace Characters.Flying.Wings
{
    public interface IWingsAnimationEvents
    {
        event Action OnOpenedWings;
        event Action OnSwing;
        event Action OnBeginCloseWings;
        event Action OnClosedWings;
    }
}
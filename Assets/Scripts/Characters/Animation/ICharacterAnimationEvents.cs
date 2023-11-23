using System;

namespace Characters.Animation
{
    public interface ICharacterAnimationEvents
    {
        event Action OnPushGroundWhenJumping;
        event Action OnPushGroundWhenSomersault;
        event Action OnFirstTouchOnLanding;
        event Action OnLandingFinished;
        event Action OnPreparingToJump;
        event Action OnLeftFootTouchTheGround;
        event Action OnRightFootTouchTheGround;
        event Action OnFinishedSomersault;
        event Action OnFallingFromUpperHit;
        event Action OnFallingFromMiddleHit;
        event Action OnFallingFromLowerHit;
        event Action OnBeginOpeningWings;
        event Action OnBeginClosingWings;
    }
}
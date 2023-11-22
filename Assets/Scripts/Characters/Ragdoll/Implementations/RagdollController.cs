using Characters.Animation;
using UnityEngine;

namespace Characters.Ragdoll
{
    internal class RagdollController : IRagdoll
    {
        private readonly Skeleton _skeleton;
        private readonly IRagdollParameters _parameters;
        private readonly ICharacterAnimation _animation;
        private readonly ICharacterAnimationEvents _animationEvents;

        public RagdollController(Skeleton skeleton, IRagdollParameters parameters, ICharacterAnimation animation, ICharacterAnimationEvents animationEvents)
        {
            _skeleton = skeleton;
            _parameters = parameters;
            _animation = animation;
            _animationEvents = animationEvents;
        }


        public void Initialize()
        {
            _animationEvents.OnFallingFromUpperHit += FallingFromUpperHit;
            _animationEvents.OnFallingFromMiddleHit += FallingFromMiddleHit;
            _animationEvents.OnFallingFromLowerHit += FallingFromLowerHit;
        }

        private void FallingFromUpperHit()
        {
            
            FallingFromHit(_parameters.ForceOnFallingByUpperHit);
        }

        private void FallingFromMiddleHit()
        {
            FallingFromHit(_parameters.ForceOnFallingByMiddleHit);
        }

        private void FallingFromLowerHit()
        {
            FallingFromHit(_parameters.ForceOnFallingByLowerHit);
        }

        private void FallingFromHit(Vector2 force)
        {
            Enable();
            _skeleton.AddForce(force);
        }

        public void Enable()
        {
            _animation.Disable();
            _skeleton.EnablePhysics();
        }


        public void Disable()
        {
            _skeleton.DisablePhysics();
            _animation.Enable();
        }

        public void Dispose()
        {
            _animationEvents.OnFallingFromUpperHit -= FallingFromUpperHit;
            _animationEvents.OnFallingFromMiddleHit -= FallingFromMiddleHit;
            _animationEvents.OnFallingFromLowerHit -= FallingFromLowerHit;
        }
    }
}
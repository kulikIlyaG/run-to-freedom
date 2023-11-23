using Characters.Animation;
using Characters.Physics;
using UnityEngine;

namespace Characters.Somersault
{
    internal class CharacterSomersaultByAnimation : ICharacterSomersault
    {
        private readonly ICharacterAnimation _animation;
        private readonly ICharacterAnimationEvents _animationEvents;
        private readonly ICharacterPhysics _physics;
        private readonly IHitBoxCollider _hitBoxCollider;
        private readonly ISomersaultParameters _parameters;
        private readonly ISomersaultAvailableChecker _somersaultAvailable;
        

        private bool _isSomersaultNow;

        public CharacterSomersaultByAnimation(ICharacterAnimation animation,
            ICharacterAnimationEvents animationEvents,
            ICharacterPhysics physics,
            IHitBoxCollider hitBoxCollider,
            ISomersaultParameters parameters,
            ISomersaultAvailableChecker somersaultAvailable)
        {
            _animation = animation;
            _animationEvents = animationEvents;
            _hitBoxCollider = hitBoxCollider;
            _physics = physics;
            _parameters = parameters;
            _somersaultAvailable = somersaultAvailable;
        }

        public bool IsSomersaultNow => _isSomersaultNow;

        public void Somersault()
        {
            if(IsSomersaultNow)
                return;
            
            if(!_somersaultAvailable.ICanSomersault())
                return;

            _isSomersaultNow = true;
            _animation.PlaySomersault();
            _hitBoxCollider.DeactivateHitBox();
        }

        
        private void AddSomersaultShiftForce()
        {
            _physics.AddForce(Vector2.right * _parameters.ShiftForce); 
        }
        
        private void OnFinishedSomersault()
        {
            _hitBoxCollider.ActivateHitBox();
            _isSomersaultNow = false;
        }

        public void Initialize()
        {
            _animationEvents.OnFinishedSomersault += OnFinishedSomersault;
            _animationEvents.OnPushGroundWhenSomersault += AddSomersaultShiftForce;
        }

        public void Dispose()
        {
            _animationEvents.OnFinishedSomersault -= OnFinishedSomersault;
            _animationEvents.OnPushGroundWhenSomersault -= AddSomersaultShiftForce;
        }
    }
}
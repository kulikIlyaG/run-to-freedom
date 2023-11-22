using Characters.Animation;
using Characters.Jump;
using Characters.Model;
using Characters.Movement;
using Characters.Physics;
using Characters.Somersault;
using Characters.Stats;
using UnityEngine;

namespace Characters
{
    public class Character : ICharacter
    {
        private readonly ICharacterPhysics _physics;
        private readonly IMovementParameters _movementParameters;
        private readonly ICharacterAnimationEvents _animationEvents;
        private readonly IHealth _health;
        
        private readonly IMovement _movement;
        private readonly IJumping _jumping;
        private readonly ICharacterSomersault _somersault;
        
        private readonly ICharacterModel _characterModel;
        private readonly ICharacterInputsModelReadOnly _input;

        protected Character(ICharacterPhysics physics,
            IMovement movement,
            IMovementParameters movementParameters,
            IJumping jumping, 
            ICharacterSomersault somersault,
            ICharacterInputsModelReadOnly input,
            ICharacterAnimationEvents animationEvents,
            IHealth health,
            ICharacterModel characterModel)
        {
            _physics = physics;
            _movement = movement;
            _movementParameters = movementParameters;
            _jumping = jumping;
            _somersault = somersault;
            _input = input;
            _animationEvents = animationEvents;
            _health = health;
            _characterModel = characterModel;
        }
        
        
        public void Initialize()
        {
            SubscribeToEvents();

            _health.Set(1f);
        }


        public void Dispose()
        {
            UnsubscribeFromEvents();
        }

        public void SetPosition(Vector2 position)
        {
            _physics.SetPosition(position);
        }
        
        public virtual void Tick()
        {
            if (_health.IsAlive)
            {
                if (_input.VerticalAxis > 0f)
                    Jump();
                else if (_input.VerticalAxis < 0f)
                    Somersault();
            }
        }
        

        public void LateTick()
        {
            _characterModel.SetPosition(_physics.Position);
        }

        private void ResetMovementSpeed()
        {
            _movementParameters.SetSpeedMultiplier(1f);
        }

        private void SlowDownMovementSpeed()
        {
            _movementParameters.SetSpeedMultiplier(0.3f);
        }


        protected void Die()
        {
            _health.Set(0f);
            _movement.Stop();
        }

        protected void Jump()
        {
            _jumping.Jump();
        }

        protected void Somersault()
        {
            _somersault.Somersault();
        }

        private void OnDestroyModel(ICharacterModel obj)
        {
            DestroyView();
        }

        protected virtual void DestroyView()
        {
            //todo destroy view
        }

        protected virtual void SubscribeToEvents()
        {
            _animationEvents.OnPreparingToJump += SlowDownMovementSpeed;
            _animationEvents.OnPushGroundWhenJumping += ResetMovementSpeed;
            _animationEvents.OnFirstTouchOnLanding += SlowDownMovementSpeed;
            _animationEvents.OnLandingFinished += ResetMovementSpeed;
            _animationEvents.OnFallingFromLowerHit += Die;
            _animationEvents.OnFallingFromMiddleHit += Die;
            _animationEvents.OnFallingFromUpperHit += Die;
            _characterModel.OnDestroy += OnDestroyModel;
        }

        protected virtual void UnsubscribeFromEvents()
        {
            _animationEvents.OnPreparingToJump -= SlowDownMovementSpeed;
            _animationEvents.OnPushGroundWhenJumping -= ResetMovementSpeed;
            _animationEvents.OnFirstTouchOnLanding -= SlowDownMovementSpeed;
            _animationEvents.OnLandingFinished -= ResetMovementSpeed;
            _animationEvents.OnFallingFromLowerHit -= Die;
            _animationEvents.OnFallingFromMiddleHit -= Die;
            _animationEvents.OnFallingFromUpperHit -= Die;
            _characterModel.OnDestroy -= OnDestroyModel;
        }
    }
}
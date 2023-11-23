using Characters.Flying;
using Characters.Physics;
using UnityEngine;
using Zenject;

namespace Characters.Movement
{
    internal class VelocityMovement : IMovement
    {
        private readonly IMovementAvailableChecker _moveAvailable; 
        
        protected readonly ICharacterPhysics _physics;
        protected readonly IMovementParameters _parameters;
        
        [InjectOptional] private readonly IFlying _flying;

        private bool _isStopped;

        protected VelocityMovement(ICharacterPhysics physics,
            IMovementParameters parameters,
            IMovementAvailableChecker moveAvailable)
        {
            _physics = physics;
            _parameters = parameters;
            _moveAvailable = moveAvailable;
        }

        public void FixedTick()
        {
            if(_isStopped)
                return;
            
            Move();
        }

        protected virtual void Move()
        {
            if (_moveAvailable.ICanMove())
            {
                _physics.SetVelocity(new Vector2(_parameters.GetSpeed(), _physics.Velocity.y));
            }
            
            if (_physics.Velocity.y < 0f && _flying is {IsEnabled: false})
            {
                _physics.AddVelocity(-(Vector2.up * _parameters.FallMultiplier * Time.deltaTime));
            }
        }


        void IMovement.Stop()
        {
            _isStopped = true;
            _physics.SetVelocity(Vector2.zero);
        }
    }
}
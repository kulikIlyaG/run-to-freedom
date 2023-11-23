using Characters;
using Characters.Animation;
using Characters.Flying;
using Characters.Jump;
using Characters.Model;
using Characters.Movement;
using Characters.Physics;
using Characters.Somersault;
using Characters.Stats;
using PlayerLogic.Model;
using Zenject;

namespace PlayerLogic
{
    public class Player : Character, IPlayer
    {
        public class Factory : PlaceholderFactory<IPlayerModel, Player>{}

        private readonly IPlayerModel _playerModel;
        private readonly IFlying _flying;

        public Player(ICharacterPhysics physics,
            IMovement movement,
            IMovementParameters movementParameters, 
            IJumping jumping, 
            ICharacterSomersault somersault,
            ICharacterInputsModelReadOnly input, 
            ICharacterAnimationEvents animationEvents,
            IHealth health, 
            IPlayerModel playerModel,
            IFlying flying)
            : base(physics, movement, movementParameters, jumping, somersault, input, animationEvents, health, playerModel)
        {
            _flying = flying;
            _playerModel = playerModel;
        }

        protected override void SubscribeToEvents()
        {
            base.SubscribeToEvents();
            _playerModel.OnSwitchedFlying += OnSwitchedFlyingMode;
        }

        private void OnSwitchedFlyingMode(bool enable)
        {
            if (enable)
                _flying.Enable();
            else _flying.Disable();
        }

        protected override void UnsubscribeFromEvents()
        {
            base.UnsubscribeFromEvents();
            _playerModel.OnSwitchedFlying -= OnSwitchedFlyingMode;
        }
    }
}
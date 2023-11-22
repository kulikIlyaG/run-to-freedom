using Characters.Animation;
using Characters.Flying.Wings;
using Characters.Model;
using Characters.Physics;
using UnityEngine;

namespace Characters.Flying
{
    public class CharacterFlyingOnWings : IFlying
    {
        private readonly ICharacterAnimation _characterAnimation;
        private readonly ICharacterAnimationEvents _characterAnimationEvents;

        private readonly IWingsAnimation _wingsAnimation;
        
        private readonly ICharacterPhysics _physics;
        private readonly IFlyingParameters _parameters;
        private readonly ICharacterInputsModelReadOnly _inputs;

        private bool _isEnabled = false;
        
        public CharacterFlyingOnWings(ICharacterAnimation characterAnimation,
            ICharacterAnimationEvents characterAnimationEvents,
            IWingsAnimation wingsAnimation,
            ICharacterPhysics physics,
            IFlyingParameters parameters,
            ICharacterInputsModelReadOnly inputs)
        {
            _characterAnimation = characterAnimation;
            _characterAnimationEvents = characterAnimationEvents;

            _wingsAnimation = wingsAnimation;
            
            _physics = physics;
            _parameters = parameters;
            _inputs = inputs;
        }

        bool IFlying.IsEnabled => _isEnabled;
        

        public void Initialize()
        {
            _characterAnimationEvents.OnBeginOpeningWings += OnBeginOpeningWings;
            _characterAnimationEvents.OnBeginClosingWings += OnBeginClosingWings;
        }


        public void Dispose()
        {
            _characterAnimationEvents.OnBeginOpeningWings += OnBeginOpeningWings;
            _characterAnimationEvents.OnBeginClosingWings += OnBeginClosingWings;
        }
        
        void IFlying.Enable()
        {
            _isEnabled = true;
            _characterAnimation.PlayFlying();
        }

        private void OnBeginOpeningWings()
        {
            _wingsAnimation.PlayOpen();
            _physics.SetGravity(0f);
        }
        
        
        private void OnBeginClosingWings()
        {
            _wingsAnimation.PlayClose();
            _physics.SetGravity(1f);
        }

        public void FixedTick()
        {
            if(!_isEnabled)
                return;
            
            _physics.AddVelocity(Vector2.up * (_inputs.VerticalAxis * (_parameters.Speed * Time.deltaTime)));
            
            if (_physics.Position.y > _parameters.MaxHeight)
            {
                _physics.SetPosition(new Vector2(_physics.Position.x, _parameters.MaxHeight));
                _physics.SetVelocity(new Vector2(_physics.Velocity.x, 0f));
            }
            else if (_physics.Position.y < _parameters.MinHeight && _physics.GravityScale <=0f)
            {
                _physics.SetPosition(new Vector2(_physics.Position.x, _parameters.MinHeight));
                _physics.SetVelocity(new Vector2(_physics.Velocity.x, 0f));
            }
        }

        void IFlying.Disable()
        {
            _isEnabled = false;
            _characterAnimation.PlayEndFlying();
        }
    }
}
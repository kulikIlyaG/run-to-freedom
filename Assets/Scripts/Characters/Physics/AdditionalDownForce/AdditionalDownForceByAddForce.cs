using Characters.Flying;
using Characters.Jump;
using UnityEngine;
using Zenject;

namespace Characters.Physics
{
    public class AdditionalDownForceByAddForce : IAdditionalDownForce
    {
        [InjectOptional] private readonly IJumping _jumping;
        [InjectOptional] private readonly IFlying _flying;
        [InjectOptional] private readonly IFlyingParameters _flyingParameters;
        
        [Inject] private readonly ICharacterPhysics _physics;
        

        public void FixedTick()
        {
            if (_jumping is {IsJumping: true})
                return;

            if (_flying is {IsEnabled: true})
                return;
            
            
            _physics.AddForce(Vector2.down * 1000f);
        }
    }
}
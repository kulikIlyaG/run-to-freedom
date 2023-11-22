using System;
using Characters.Flying;
using Characters.Jump;
using Characters.Model;
using Characters.Movement;
using Characters.Somersault;
using Level.World;
using UnityEngine;

namespace PlayerLogic.Model
{
    [Serializable]
    public class PlayerModel : CharacterModel, IPlayerModel
    {
        [SerializeField] private FlyingParameters _flyingParameters;
        
        [Header("Vision landscape parameters")]
        [SerializeField] private float _visionLength = 50f;
        [SerializeField] [Range(0f,1f)] private float _visionOffset = 0.25f;
        
        public event Action<bool> OnSwitchedFlying;
        
        public PlayerModel(string id, MovementParameters movementParameters,
            JumpingParameters jumpingParameters,
            SomersaultParameters somersaultParameters) 
            : base(id, movementParameters, jumpingParameters, somersaultParameters)
        {
        }

        Vector2 IWorldRunner.BehindVisionPoint => Position + -Vector2.right * (_visionLength * _visionOffset);
        Vector2 IWorldRunner.FrontVisionPoint => Position + Vector2.right * (_visionLength - _visionLength * _visionOffset);

        public IFlyingParameters FlyingParameters => _flyingParameters;

        void IPlayerModel.BeginFlying()
        {
            OnSwitchedFlying?.Invoke(true);
        }

        void IPlayerModel.EndFlying()
        {
            OnSwitchedFlying?.Invoke(false);
        }

    }
}
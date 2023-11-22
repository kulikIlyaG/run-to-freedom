using System;
using UnityEngine;

namespace Characters.Jump
{
    [Serializable]
    public class JumpingParameters : IJumpingParameters
    {
        [SerializeField] private Vector2 _direction = new Vector2(0.6f, 1f);
        [SerializeField] private float _power = 100000f;
        [SerializeField] private float _maxJumpHeight = 1.5f;
        [SerializeField] private float _additionalFallImpulse = 1000f;

        public float MaxJumpHeight => _maxJumpHeight;
        public float AdditionalFallImpulse => _additionalFallImpulse;
        public Vector2 Direction => _direction;
        public float Power => _power;
    }
}
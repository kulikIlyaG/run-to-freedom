using System;
using UnityEngine;

namespace Characters.Flying
{
    [Serializable]
    public class FlyingParameters : IFlyingParameters
    {
        [SerializeField] private float _minHeight = 2f;
        [SerializeField] private float _maxHeight = 10f;
        [SerializeField] private float _speed = 1f;

        public float MinHeight => _minHeight;
        public float MaxHeight => _maxHeight;
        public float Speed => _speed;
    }
}
using System;
using UnityEngine;

namespace Characters.Somersault
{
    [Serializable]
    public class SomersaultParameters : ISomersaultParameters
    {
        [SerializeField] private float _shiftForce = 250f;
        
        public float ShiftForce => _shiftForce;
    }
}
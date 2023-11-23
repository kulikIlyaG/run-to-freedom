using System;
using Characters.Jump;
using Characters.Movement;
using Characters.Somersault;
using UnityEngine;

namespace Characters.Model
{
    public interface ICharacterModel
    {
        IMovementParameters MovementParameters { get; }
        IJumpingParameters JumpingParameters { get; }
        ISomersaultParameters SomersaultParameters { get; }
        
        string Id { get; }

        event Action<ICharacterModel> OnDestroy; 
        
        void SetPosition(Vector2 position);
    }
}
using System;
using Characters.Jump;
using Characters.Movement;
using Characters.Somersault;
using UnityEngine;

namespace Characters.Model
{
    [Serializable]
    public class CharacterModel : ICharacterModel
    {
        [SerializeField] private string _id;
        [SerializeField] private MovementParameters _movementParameters;
        [SerializeField] private JumpingParameters _jumpingParameters;
        [SerializeField] private SomersaultParameters _somersaultParameters;
        
        public event Action<ICharacterModel> OnDestroy;
        
        public CharacterModel(string id, MovementParameters movementParameters,
            JumpingParameters jumpingParameters, SomersaultParameters somersaultParameters)
        {
            _id = id;
            _movementParameters = movementParameters;
            _jumpingParameters = jumpingParameters;
            _somersaultParameters = somersaultParameters;
        }
        
        public IMovementParameters MovementParameters => _movementParameters;
        public IJumpingParameters JumpingParameters => _jumpingParameters;
        public ISomersaultParameters SomersaultParameters => _somersaultParameters;
        public Vector2 Position { private set; get; }
        public string Id => _id;


        public void SetPosition(Vector2 position)
        {
            Position = position;
        }
    }
}
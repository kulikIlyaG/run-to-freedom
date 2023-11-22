using System;
using Root.Systems.CharactersHolder;
using PlayerLogic.Model;
using UnityEngine;

namespace PlayerLogic
{
    public class PlayerController : IPlayerController
    {
        private readonly Player.Factory _factory;
        private readonly Vector2 _playerStartPosition;
        private readonly ICharactersHolderSystem _charactersHolderSystem;

        private IPlayerModel _model;
        
        private IPlayer _currentInstance;

        public event Action<IPlayerModel> OnPlayerCreated;
        
        public PlayerController(ICharactersHolderSystem charactersHolderSystem, Player.Factory factory, PlayerModel model, Vector2 playerStartPosition)
        {
            _charactersHolderSystem = charactersHolderSystem;
            _playerStartPosition = playerStartPosition;
            _factory = factory;
            _model = model;
        }

        public IPlayerModel Player => _model;
        
        void IPlayerController.CreatePlayer()
        {
            var model = GetPlayerModel();
            model.MovementParameters.SetSpeedMultiplier(0f);
            
            _currentInstance = _factory.Create(model);
            _currentInstance.SetPosition(_playerStartPosition);
            _charactersHolderSystem.Register(model);
            OnPlayerCreated?.Invoke(model);
        }

        void IPlayerController.Begin()
        {
            _model.MovementParameters.SetSpeedMultiplier(1f);
        }

        private IPlayerModel GetPlayerModel()
        {
            return _model;
        }
    }
}
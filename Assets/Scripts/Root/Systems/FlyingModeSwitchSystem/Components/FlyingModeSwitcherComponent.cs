using Root.Systems.CharactersHolder;
using PlayerLogic.Model;
using UnityEngine;
using Zenject;

namespace Root.Systems.FlyingModeSwitchSystem.Components
{
    public class FlyingModeSwitcherComponent : MonoBehaviour
    {
        [SerializeField] private float _durationInSeconds;

        private IFlyingModeSwitchSystem _flyingModeSwitch;
        private ICharactersHolderSystemReadOnly _charactersHolderSystem;

        [Inject]
        private void Construct(IFlyingModeSwitchSystem flyingModeSwitch, ICharactersHolderSystemReadOnly charactersHolderSystem)
        {
            _flyingModeSwitch = flyingModeSwitch;
            _charactersHolderSystem = charactersHolderSystem;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_charactersHolderSystem.Contains(other.name))
            {
                var effectTarget = _charactersHolderSystem.Get(other.name);
                if (effectTarget is IPlayerModel playerModel)
                {
                    _flyingModeSwitch.EnableFlying(playerModel, _durationInSeconds);
                }
            }
        }
    }
}
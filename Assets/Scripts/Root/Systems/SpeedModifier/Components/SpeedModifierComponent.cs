using Root.Systems.CharactersHolder;
using UnityEngine;
using Zenject;

namespace Root.Systems.SpeedModifier.Components
{
    public class SpeedModifierComponent : MonoBehaviour
    {
        [SerializeField] private SpeedModifierData _speedModifierData;
        
        private ISpeedModifierSystem _speedModifierSystem;
        private ICharactersHolderSystemReadOnly _charactersHolderSystem;

        [Inject]
        private void Construct(ISpeedModifierSystem speedModifierSystem, ICharactersHolderSystemReadOnly charactersHolderSystem)
        {
            _speedModifierSystem = speedModifierSystem;
            _charactersHolderSystem = charactersHolderSystem;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_charactersHolderSystem.Contains(other.name))
            {
                var effectTarget = _charactersHolderSystem.Get(other.name);
                _speedModifierSystem.Apply(_speedModifierData, effectTarget.MovementParameters);
            }
        }
    }
}
using Root.Systems.GamePlayInput;

namespace Characters.Model
{
    public class CharacterInputsModel : ICharacterInputsModelReadOnly
    {
        private readonly IGameplayInputModelReadOnly _gameInputs;

        public CharacterInputsModel(IGameplayInputModelReadOnly gameInputs)
        {
            _gameInputs = gameInputs;
        }

        float ICharacterInputsModelReadOnly.VerticalAxis => _gameInputs.VerticalAxis;
    }
}
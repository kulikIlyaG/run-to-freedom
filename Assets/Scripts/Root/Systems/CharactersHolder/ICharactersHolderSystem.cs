using Characters.Model;

namespace Root.Systems.CharactersHolder
{
    public interface ICharactersHolderSystem : ICharactersHolderSystemReadOnly
    {
        void Register(ICharacterModel model);
    }
}
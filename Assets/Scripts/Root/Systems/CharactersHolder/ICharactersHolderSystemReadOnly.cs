using Characters.Model;

namespace Root.Systems.CharactersHolder
{
    public interface ICharactersHolderSystemReadOnly
    {
        ICharacterModel Get(string id);
        bool Contains(string id);
    }
}
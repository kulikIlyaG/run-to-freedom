using Characters.Model;

namespace Root.Systems.CharactersHolder
{
    /// <summary>
    /// Завел ее так-как изначально планировалось более одного персонажа на экране. и это было бы более полезно чем сейчас.
    /// Однако пример ее использования описывает мои планы на нее 
    /// </summary>
    public interface ICharactersHolderSystem : ICharactersHolderSystemReadOnly
    {
        void Register(ICharacterModel model);
    }
}
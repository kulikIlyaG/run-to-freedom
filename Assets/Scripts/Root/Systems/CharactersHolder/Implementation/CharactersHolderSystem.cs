using System;
using System.Collections.Generic;
using Characters.Model;

namespace Root.Systems.CharactersHolder
{
    public class CharactersHolderSystem : ICharactersHolderSystem
    {
        private readonly Dictionary<string, ICharacterModel> _content = new();

        public void Register(ICharacterModel model)
        {
            if (_content.ContainsKey(model.Id))
                throw new Exception("you are trying to register a duplicate! Most likely something went wrong!");

            _content.Add(model.Id, model);
            model.OnDestroy += Unregister;
        }

        private void Unregister(ICharacterModel model)
        {
            _content.Remove(model.Id);
        }
        
        public ICharacterModel Get(string id)
        {
            return _content[id];
        }

        public bool Contains(string id)
        {
            return _content.ContainsKey(id);
        }
    }
}
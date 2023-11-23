using System;
using Zenject;

namespace Characters.Somersault
{
    public interface ICharacterSomersault : IInitializable, IDisposable
    {
        bool IsSomersaultNow { get; }
        void Somersault();
    }
}
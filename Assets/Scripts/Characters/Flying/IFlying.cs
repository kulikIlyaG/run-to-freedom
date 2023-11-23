using System;
using Zenject;

namespace Characters.Flying
{
    public interface IFlying : IFixedTickable, IInitializable, IDisposable
    {
        bool IsEnabled { get; }
        void Enable();
        void Disable();
    }
}
using System;
using Zenject;

namespace Characters.Ragdoll
{
    public interface IRagdoll : IInitializable, IDisposable
    {
        void Enable();
        void Disable();
    }
}
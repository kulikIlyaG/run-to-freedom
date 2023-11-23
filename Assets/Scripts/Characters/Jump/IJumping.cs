using System;
using Zenject;

namespace Characters.Jump
{
    public interface IJumping : IInitializable, IDisposable, IFixedTickable
    {
        bool IsJumping { get; }
        void Jump();
    }
}
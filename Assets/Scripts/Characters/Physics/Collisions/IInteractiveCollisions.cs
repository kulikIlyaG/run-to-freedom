using System;
using Zenject;

namespace Characters.Physics
{
    public interface IInteractiveCollisions : IInitializable, IDisposable
    {
        event Action<CollisionInfo> OnCollision;
    }
}
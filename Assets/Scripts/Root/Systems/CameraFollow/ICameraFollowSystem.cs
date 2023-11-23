using System;
using Zenject;

namespace Root.Systems.CameraFollowSystem
{
    public interface ICameraFollowSystem : ITickable, IInitializable, IDisposable
    {
    }
}
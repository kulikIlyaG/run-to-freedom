using System;
using Level.World;
using Zenject;

namespace Level.Controller
{
    public interface ILevelController : IInitializable, IDisposable
    {
        event Action<IWorldRunner> OnCreatedWorldRunner;
        IWorldRunner Runner { get; }
        void UpdateLevel();
    }
}
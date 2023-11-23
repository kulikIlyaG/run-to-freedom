using System;
using Zenject;

namespace Level.Controller
{
    public interface ILevelController : IInitializable, IDisposable
    {
        void UpdateLevel();
    }
}
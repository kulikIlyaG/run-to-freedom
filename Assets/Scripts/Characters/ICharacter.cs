using System;
using UnityEngine;
using Zenject;

namespace Characters
{
    public interface ICharacter : IInitializable, ITickable, ILateTickable, IDisposable
    {
        void SetPosition(Vector2 position);
    }
}
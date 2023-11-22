using UnityEngine;
using Zenject;

namespace Root.Systems.GamePlayInput.Touch
{
    public interface IAxisUIControllerExecutor : ITickable
    {
        Vector2 Axis { get; }
    }
}
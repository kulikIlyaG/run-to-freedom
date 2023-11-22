using Level.World;
using UnityEngine;

namespace Level.Generators
{
    public interface IWorldBoxView
    {
        string Name { get; set; }
        Vector2 StartAnchor { get; }
        Vector2 EndAnchor { get; }
        bool IsVisible(IWorldRunner _runner);
        void SetPositionStartAnchor(Vector2 point);
        void DestroyInstance();
    }
}
using UnityEngine;

namespace Level.World
{
    public interface IWorldRunner
    {
        Vector2 BehindVisionPoint { get; }
        Vector2 FrontVisionPoint { get; }
        Vector2 Position { get; }
    }
}
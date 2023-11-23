using UnityEngine;

namespace Root.Systems.CameraFollowSystem
{
    public interface ICameraFollowTarget
    {
        Vector2 Position { get; }
    }
}
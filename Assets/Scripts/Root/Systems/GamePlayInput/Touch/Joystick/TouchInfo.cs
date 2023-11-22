using UnityEngine;

namespace Root.Systems.GamePlayInput.Touch.Joystick
{
    public struct TouchInfo
    {
        public readonly Vector2 Point;
        public readonly Vector2 Delta;

        public TouchInfo(Vector2 point, Vector2 delta)
        {
            Point = point;
            Delta = delta;
        }
    }
}
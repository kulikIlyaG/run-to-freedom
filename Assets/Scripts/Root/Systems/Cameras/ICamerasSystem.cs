using UnityEngine;

namespace Root.Systems.CamerasSystem
{
    public interface ICamerasSystem
    {
        bool IsVisiblePoint(Vector3 point);
    }
}
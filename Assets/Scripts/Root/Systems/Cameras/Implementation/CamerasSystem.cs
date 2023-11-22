using UnityEngine;

namespace Root.Systems.CamerasSystem
{
    public class CamerasSystem : ICamerasSystem
    {
        private readonly Camera _gameCamera;
        private readonly Camera _backgroundsCamera;

        public CamerasSystem(Camera gameCamera, Camera backgroundsCamera)
        {
            _gameCamera = gameCamera;
            _backgroundsCamera = backgroundsCamera;
        }

        public bool IsVisiblePoint(Vector3 point)
        {
            var viewPort = _gameCamera.WorldToViewportPoint(point);

            if (viewPort.x < 0f || viewPort.y < 0f)
            {
                viewPort = _backgroundsCamera.WorldToViewportPoint(point);
                
                if (viewPort.x < 0f || viewPort.y < 0f)
                    return false;
            }
            
            return true;
        }
    }
}
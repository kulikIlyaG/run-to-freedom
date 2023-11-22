using Level.World;
using UnityEngine;

namespace Level.Generators.Components
{
    public abstract class WorldBoxComponent : MonoBehaviour, IWorldBoxView
    {
        public string Name
        {
            get => gameObject.name;
            set => gameObject.name = value;
        }
        
        public abstract Vector2 StartAnchor { get; }
        public abstract Vector2 EndAnchor { get; }

        public virtual bool IsVisible(IWorldRunner _runner)
        {
            return EndAnchor.x > _runner.BehindVisionPoint.x;
        }

        public virtual void SetPositionStartAnchor(Vector2 point)
        {
            transform.position = point;
        }

        public virtual void DestroyInstance()
        {
            Destroy(gameObject);
        }
    }
}
using UnityEngine;

namespace Characters.Physics
{
    public class CollisionInfo
    {
        public readonly Collision2D Collision;

        public CollisionInfo(Collision2D collision)
        {
            Collision = collision;
        }

        public string Tag => Collision.collider.tag;

        public Vector2 GetAverageContactPoint()
        {
            return Collision.contacts[0].point;
        }
    }
}
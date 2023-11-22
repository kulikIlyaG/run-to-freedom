using UnityEngine;

namespace Components.Physics2DExtensions
{
    public class CollisionsIgnoreList : MonoBehaviour
    {
        [SerializeField] private Collider2D[] _listA;
        [SerializeField] private Collider2D[] _listB;

        private void Awake()
        {
            foreach (var a in _listA)
            {
                foreach (var b in _listB)
                {
                    Physics2D.IgnoreCollision(a, b);
                }
            }
        }
    }
}
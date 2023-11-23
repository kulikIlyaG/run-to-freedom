using System;
using UnityEngine;

namespace Characters.Ragdoll
{
    [Serializable]
    internal class Skeleton
    {
        [SerializeField] private Bone[] _bones;

        public void EnablePhysics()
        {
            foreach (Bone bone in _bones)
            {
                bone.EnablePhysics();
            }
        }


        public void DisablePhysics()
        {
            foreach (Bone bone in _bones)
            {
                bone.DisablePhysics();
            }
        }

        public void AddForce(Vector2 force)
        {
            foreach (Bone bone in _bones)
            {
                bone.AddForce(force);
            }
        }
    }
}
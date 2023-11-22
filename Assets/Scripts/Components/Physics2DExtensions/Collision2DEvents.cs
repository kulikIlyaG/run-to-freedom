using System;
using UnityEngine;

namespace Components.Physics2DExtensions
{
    public class Collision2DEvents : MonoBehaviour
    {
        public event Action<Collision2D> OnEnter, OnStay, OnExit; 
        
        public virtual void OnCollisionEnter2D(Collision2D other)
        {
            OnEnter?.Invoke(other);
        }

        public virtual void OnCollisionStay2D(Collision2D other)
        {
            OnStay?.Invoke(other);
        }

        public virtual void OnCollisionExit2D(Collision2D other)
        {
            OnExit?.Invoke(other);
        }
    }
}
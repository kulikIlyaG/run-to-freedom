using System;

namespace Components.Physics2DExtensions
{
    public interface IGroundCheck
    {
        public bool IsGrounded { get; }
        public event Action<bool> OnIsGroundedChanged;
    }
}
using System;

namespace PlayerLogic.Model
{
    public interface IPlayerModelReadOnly
    {
        event Action<bool> OnSwitchedFlying;
    }
}
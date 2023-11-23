using System;
using PlayerLogic.Model;

namespace PlayerLogic
{
    public interface IPlayerControllerReadOnly
    {
        event Action<IPlayerModel> OnPlayerCreated;
        IPlayerModel Player { get; }
    }
}
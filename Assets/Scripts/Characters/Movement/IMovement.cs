using Zenject;

namespace Characters.Movement
{
    public interface IMovement : IFixedTickable
    {
        void Stop();
    }
}
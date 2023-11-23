using System;
using Zenject;

namespace Root.Services.Timers
{
    
    /// <summary>
    /// Обычный сервис для реализации теймеров
    /// Почему в проекте 1 сервис?
    /// Я привык делать именно сервисы как тулы напрочь не относящимися к какой либо бизнес логике проекта
    /// К примеру сервисом еще было бы: аналитика, реклама, локализация и тд
    /// </summary>
    public interface ITimersService : ITickable
    {
        bool TryGetTimer(long id, out Timer timer);
        Timer AddTimer(DateTime endTime);
        void StopTimer(long id);
        void StopTimer(Timer timer);
        void PauseTimer(long id, bool isPause);
        void PauseTimer(Timer timer, bool isPause);
    }
}
using System;
using Zenject;

namespace Characters.Flying.Wings
{
    public interface IWingsAnimation : IInitializable, IDisposable
    {
        void PlayOpen();
        void PlayClose();
    }
}
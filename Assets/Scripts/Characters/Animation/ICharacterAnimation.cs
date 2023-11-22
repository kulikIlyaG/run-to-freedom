using System;
using Characters.Damage;
using Zenject;

namespace Characters.Animation
{
    public interface ICharacterAnimation : IInitializable, IDisposable
    {
        void PlayJump();
        void PlaySomersault();
        void UpdateHorizontalSpeed(float normalizeSpeed);
        void UpdateVerticalSpeed(float signSpeed);
        void PlayFallingFromHit(HitLevel hitLevel);
        void PlayFlying();
        void PlayEndFlying();
        void Disable();
        void Enable();
    }
}
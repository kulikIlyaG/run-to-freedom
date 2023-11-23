using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Root.Audio.Components;
using UnityEngine;
using Zenject;

namespace Root.Audio
{
    /// <summary>
    /// Небольшой пул на аудио проигрыватели
    /// Есть активные и нет
    /// не активные если есть переиспользуются по запросу
    /// а если нет делаются новые по завершению их работы если лимит не превышен попадают в список не активных, иначе удаляются
    /// </summary>
    /// <typeparam name="TRaiser">Конкретный тип источника звука</typeparam>
    public class AudioRaisersPool<TRaiser> : IAudioRaisersPool where TRaiser : AudioRaiserComponent
    {
        private readonly int _countMaxRaisersInactiveInstances;
        private readonly DiContainer _container;
        private readonly TRaiser _raiserPrefab;
        private readonly Transform _activeRaisersParent;
        private readonly Transform _inactiveRaisersParent;

        private readonly Queue<TRaiser> _inactiveRaiser = new();
        private readonly HashSet<TRaiser> _activeRaisers = new();

        public AudioRaisersPool(int countMaxRaisersInactiveInstances, DiContainer container, TRaiser raiserPrefab, Transform activeRaisersParent, Transform inactiveRaisersParent)
        {
            _countMaxRaisersInactiveInstances = countMaxRaisersInactiveInstances;
            _container = container;
            _raiserPrefab = raiserPrefab;
            _activeRaisersParent = activeRaisersParent;
            _inactiveRaisersParent = inactiveRaisersParent;
        }

        async UniTask IAudioRaisersPool.PlayAsync(IAudioClipData fx)
        {
            TRaiser raiser = GetRaiserToPlay();
            await raiser.RaiseAsync(fx);
            DeactivateRaiser(raiser);
        }

        async UniTask IAudioRaisersPool.PlayAtPointAsync(IAudioClipData fx, Vector3 point)
        {
            TRaiser raiser = GetRaiserToPlay();
            raiser.transform.position = point;
            await raiser.RaiseAsync(fx);
        }

        private void DeactivateRaiser(TRaiser raiser)
        {
            if (_activeRaisers.Contains(raiser))
                _activeRaisers.Remove(raiser);
            
            if (_inactiveRaiser.Count < _countMaxRaisersInactiveInstances)    
            {
                if (!_inactiveRaiser.Contains(raiser))
                {
                    _inactiveRaiser.Enqueue(raiser);
                    raiser.transform.SetParent(_inactiveRaisersParent);
                }
            }
            else
            {
                raiser.DestroyInstance();
            }
        }

        private TRaiser GetRaiserToPlay()
        {
            var instance = GetRaiser();
            instance.transform.SetParent(_activeRaisersParent);
            return instance;
        }

        private TRaiser GetRaiser()
        {
            if (_inactiveRaiser.Count > 0)
            {
                return _inactiveRaiser.Dequeue();
            }

            var instance = CreateNewRaiserInstance();
            return instance;
        }

        private TRaiser CreateNewRaiserInstance()
        {
            return _container.InstantiatePrefabForComponent<TRaiser>(_raiserPrefab, Vector3.zero,
                Quaternion.identity, null);
        }
    }
}
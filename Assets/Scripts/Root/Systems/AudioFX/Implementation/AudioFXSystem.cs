using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Root.Systems.AudioFX
{
    public class AudioFXSystem : IAudioFXSystem
    {
        internal const int MAX_RAISER_INSTANCES_COUNT = 5;

        private readonly IAudioFXRaisersPool _pool;

        public AudioFXSystem(IAudioFXRaisersPool pool)
        {
            _pool = pool;
        }

        public async UniTask PlayAsync(IAudioFX fx)
        {
            await _pool.PlayAsync(fx);
        }

        public async UniTask PlayAtPointAsync(IAudioFX fx, Vector3 point)
        {
            await _pool.PlayAtPointAsync(fx, point);
        }
    }
}
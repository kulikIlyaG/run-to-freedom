using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Root.Audio.Components
{
    public class AudioRaiserComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;

        public async UniTask RaiseAsync(IAudioClipData data)
        {
            _source.volume = data.Volume;
            await _source.PlayAsync(data.Clip);
        }

        public void DestroyInstance()
        {
            Destroy(gameObject);
        }
    }
}
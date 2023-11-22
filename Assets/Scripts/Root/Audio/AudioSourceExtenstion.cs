using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Root.Audio
{
    public static class AudioSourceExtenstion
    {
        public static async UniTask PlayAsync(this AudioSource source, AudioClip clip)
        {
            source.clip = clip;
            source.Play();

            await UniTask.WaitWhile(() =>
            {
#if UNITY_EDITOR
                return source != null && source.isPlaying;
#else
                return source.isPlaying;
#endif
            });
        }
    }
}
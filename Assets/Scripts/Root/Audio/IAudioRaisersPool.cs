using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Root.Audio
{
    public interface IAudioRaisersPool
    {
        UniTask PlayAsync(IAudioClipData data);
        UniTask PlayAtPointAsync(IAudioClipData data, Vector3 point);
    }
}
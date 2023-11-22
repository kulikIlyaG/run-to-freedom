using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Root.Systems.AudioFX
{
    public interface IAudioFXSystem
    {
        UniTask PlayAsync(IAudioFX fx);
        UniTask PlayAtPointAsync(IAudioFX fx, Vector3 point);
    }
}
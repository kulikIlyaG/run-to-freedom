using UnityEngine;

namespace Root.Systems.AudioFX
{
    [CreateAssetMenu(fileName = "Audio FX", menuName = "Audio/FX/Array")]
    public class AudioFXSO : ScriptableObject, IAudioFX
    {
        [SerializeField] private AudioClip[] _clips;
        [SerializeField] [Range(0f, 1f)] private float _volume;
        public AudioClip Clip => _clips[Random.Range(0, _clips.Length)];
        public float Volume => _volume;
    }
}
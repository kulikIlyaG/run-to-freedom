using UnityEngine;

namespace Root.Systems.AudioAmbient
{
    [CreateAssetMenu(fileName = "Audio Ambient", menuName = "Audio/Ambient")]
    public class AudioAmbientSO : ScriptableObject, IAudioAmbient
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField] [Range(0f, 1f)] private float _volume;
        public AudioClip Clip => _clip;
        public float Volume => _volume;
        public string Id => name;
    }
}
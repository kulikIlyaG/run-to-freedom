namespace Root.Systems.AudioAmbient
{
    public class AudioAmbientSystem : IAudioAmbientSystem
    {
        internal const int MAX_RAISER_INSTANCES_COUNT = 2;
        
        private readonly IAudioAmbientRaisersPool _pool;

        private string _currentAmbient;

        public AudioAmbientSystem(IAudioAmbientRaisersPool pool)
        {
            _pool = pool;
        }

        public void PlayAmbient(IAudioAmbient ambient)
        {
            if(!string.IsNullOrEmpty(_currentAmbient) && _currentAmbient.Equals(ambient.Id))
                return;
            
            _currentAmbient = ambient.Id;
            _pool.PlayAsync(ambient);
        }
    }
}
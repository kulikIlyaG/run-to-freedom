using System;
using Level.Backgrounds.Generation;
using Level.Controller.Generation;
using Level.World;
using Level.World.Data;
using Root.Systems.AudioAmbient;
using PlayerLogic;
using PlayerLogic.Model;

namespace Level.Controller
{
    public class LevelController : ILevelController
    {
        private readonly IChunksGenerator _chunksGenerator;
        private readonly IBackgroundsGenerator _backgroundsGenerator;
        private readonly IPlayerControllerReadOnly _playerController;
        private readonly IAudioAmbientSystem _audioAmbientSystem;
        private readonly IWorldDefinition _worldDefinition;

        private IWorldRunner _runner;
        
        public LevelController(IPlayerControllerReadOnly playerController,
            IChunksGenerator chunksGenerator,
            IBackgroundsGenerator backgroundsGenerator,
            IAudioAmbientSystem audioAmbientSystem,
            IWorldDefinition worldDefinition)
        {
            _backgroundsGenerator = backgroundsGenerator;
            _chunksGenerator = chunksGenerator;
            _playerController = playerController;
            _audioAmbientSystem = audioAmbientSystem;
            _worldDefinition = worldDefinition;
        }

        public event Action<IWorldRunner> OnCreatedWorldRunner;

        public IWorldRunner Runner => _runner;

        public void UpdateLevel()
        {
            _chunksGenerator.UpdateGeneration(_runner);
            _backgroundsGenerator.UpdateGeneration(_runner);
        }
        
        public void Initialize()
        {
            _playerController.OnPlayerCreated += OnPlayerCreated;
        }

        public void Dispose()
        {
            _playerController.OnPlayerCreated -= OnPlayerCreated;
        }

        private void OnPlayerCreated(IPlayerModel obj)
        {
            SetRunner(obj);
            PlayAudioAmbient();
        }

        private void PlayAudioAmbient()
        {
            IAudioAmbient[] audioAmbientList =
                _worldDefinition.GetBiomeByDistance(_runner.FrontVisionPoint.x).GetAmbientAudio();

            foreach (IAudioAmbient ambient in audioAmbientList)
            {
                _audioAmbientSystem.PlayAmbient(ambient);
            }
        }

        private void SetRunner(IWorldRunner runner)
        {
            _runner = runner;
            OnCreatedWorldRunner?.Invoke(_runner);
        }
    }
}
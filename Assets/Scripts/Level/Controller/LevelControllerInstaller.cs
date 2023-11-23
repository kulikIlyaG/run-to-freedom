using Level.Backgrounds.Generation;
using Level.Controller.Generation;
using Level.Controller;
using Level.World.Data;
using UnityEngine;
using Zenject;

namespace Level.Controller
{
    public class LevelControllerInstaller : MonoInstaller
    {
        [SerializeField] private Vector2 _worldStartAnchor;
        [SerializeField] private WorldDefinition _worldDefinition;
        [SerializeField] private Transform _parentForChunks;
        [SerializeField] private Transform _parentForBackgrounds;

        public override void InstallBindings()
        {
            Container.Bind<IBackgroundsGenerator>().To<BackgroundsGenerator>().FromNew().AsSingle().WithArguments(_worldStartAnchor, _worldDefinition, _parentForBackgrounds)
                .NonLazy();
            Container.Bind<IChunksGenerator>().To<ChunksGeneration>().FromNew().AsSingle().WithArguments(_worldStartAnchor, _worldDefinition, _parentForChunks).NonLazy();
            Container.BindInterfacesTo<LevelController>().FromNew().AsSingle().WithArguments(_worldDefinition).NonLazy();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(_worldStartAnchor, 0.5f);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_worldStartAnchor, _worldStartAnchor + Vector2.right * 100f);
        }
    }
}
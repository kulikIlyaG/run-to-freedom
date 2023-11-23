using Level.World;
using PlayerLogic.Model;
using UnityEngine;
using Zenject;

namespace PlayerLogic
{
    public class PlayerControllerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private PlayerModel _playerModel;
        [SerializeField] private Vector2 _playerStartPosition;
        

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerController>().FromNew().AsSingle().WithArguments(_playerStartPosition, _playerModel).NonLazy();
            
            Container.BindFactory<IPlayerModel, Player, Player.Factory>().FromSubContainerResolve().ByNewContextPrefab<PlayerInstaller>(_playerPrefab);
        }

        private void OnDrawGizmos()
        {
            IWorldRunner runner = _playerModel as IWorldRunner;
            Gizmos.color = Color.yellow;
            Vector3 cubeSize = new Vector3(0.75f, 2f, 1f);
            Gizmos.DrawCube(_playerStartPosition + Vector2.up * (cubeSize.y / 2f), cubeSize);

            Gizmos.color = Color.cyan;
            Vector2 offset = Vector2.up * (cubeSize.y / 2f);
            Gizmos.DrawLine(runner.BehindVisionPoint + offset, runner.FrontVisionPoint + offset);
        }
    }
}
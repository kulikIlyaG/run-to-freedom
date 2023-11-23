using Characters.Model;
using Characters.Physics;
using Characters.Animation;
using Characters.Audio;
using Characters.Particles;
using Characters.Stats;
using Characters.Damage;
using Characters.Ragdoll;
using Characters.Movement;
using Characters.Jump;
using Characters.Somersault;
using Components.Physics2DExtensions;
using Root.Systems.AudioFX;
using UnityEngine;
using Zenject;

namespace Characters.Installers
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private CapsuleCollider2D _hitBoxCollider;
        [SerializeField] private Collider2D _mainHitBoxCollider;
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimatorEvents _animatorEvents;
        [SerializeField] private GroundedStateUpdater _groundedStateUpdater;
        [SerializeField] private CharacterModel _testingCharacterModel;

        [SerializeField] private CharacterParticles.TransformAnchoredParticle _leftFootGroundSplash;
        [SerializeField] private CharacterParticles.TransformAnchoredParticle _rightFootGroundSplash;
        [SerializeField] private Collision2DEvents _interactiveCollisionEvents;

        [SerializeField] private Skeleton _ragdollSkeleton;
        [SerializeField] private RagdollParameters _ragdollParameters;
        
        [SerializeField] private FootstepsAudioFxContainer _footstepsFx;
        [SerializeField] private BreathingAudioFXContainer _breathingFx;
        [SerializeField] private AudioFXSO _jumpingFx;
        [SerializeField] private AudioFXSO _landingFx;

        [Header("Hit box parameters")]
        [SerializeField] private float _notHitZonePercent;
        [SerializeField] private float _legsPercentHeight;
        [SerializeField] private float _bodyPercentHeight;

        [InjectOptional] protected ICharacterModel _injectedCharacterModel;
        
        public override void InstallBindings()
        {
            BindCharacterEntity();
            BindStats();
            BindPhysics();
            BindAudio();
            BindAnimation();
            
            BindMovement();
            BindJumping();
            BindSomersault();

            Container.BindInterfacesTo<CharacterParticles>().FromNew().AsSingle().
                WithArguments(_leftFootGroundSplash, _rightFootGroundSplash).NonLazy();
            Container.BindInterfacesTo<CharacterInputsModel>().FromNew().AsSingle().NonLazy();
        }

        protected virtual void BindCharacterEntity()
        {
            Container.BindInterfacesAndSelfTo<Character>().FromNew().AsSingle().WithArguments(_injectedCharacterModel ?? _testingCharacterModel).NonLazy();
        }

        protected virtual  void BindStats()
        {
            Container.BindInterfacesTo<DamageExecutor>().FromNew().AsSingle().
                WithArguments(new HitBoxParameters(_hitBoxCollider.size.y, _notHitZonePercent, _legsPercentHeight, _bodyPercentHeight, _rigidbody.transform)).NonLazy();
            Container.BindInterfacesTo<Health>().FromNew().AsSingle().NonLazy();
        }

        protected virtual void BindPhysics()
        {
            Container.BindInterfacesTo<CharacterPhysicsRigidbody2D>().FromNew().AsSingle()
                .WithArguments(_rigidbody).NonLazy();
            Container.BindInterfacesTo<GroundedStateUpdater>().FromInstance(_groundedStateUpdater).AsSingle().NonLazy();
            
            Container.BindInterfacesTo<AdditionalDownForceByAddForce>().FromNew().AsSingle().NonLazy();
            
            Container.Bind<IHitBoxCollider>().To<HitBoxColliderController>().FromNew().AsSingle()
                .WithArguments(_mainHitBoxCollider).NonLazy();
            
            Container.BindInterfacesTo<InteractiveCollisions>().FromNew().AsSingle().
                WithArguments(_interactiveCollisionEvents).NonLazy();
            Container.BindInterfacesTo<ObstaclesCollisionsDetector>().FromNew().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<RagdollController>().FromNew().AsSingle().
                WithArguments(_ragdollSkeleton, _ragdollParameters).NonLazy();
        }

        protected virtual void BindAudio()
        {
            Container.BindInterfacesTo<CharacterRunningFootstepsAudio>().FromNew().AsSingle().WithArguments(_footstepsFx).NonLazy();
            Container.BindInterfacesTo<CharacterJumpingAndLandingFootstepsAudio>().FromNew().AsSingle()
                .WithArguments(_footstepsFx).NonLazy();

            Container.BindInterfacesTo<CharacterBreathingAudio>().FromNew().AsSingle().WithArguments(_breathingFx).NonLazy();
        }

        protected virtual void BindAnimation()
        {
            Container.BindInterfacesTo<AnimatorEvents>().FromInstance(_animatorEvents).AsSingle().NonLazy();
            Container.BindInterfacesTo<AnimationByAnimator>().FromNew().AsSingle().WithArguments(_animator).NonLazy();
        }

        private void BindSomersault()
        {
            ISomersaultParameters parameters = _injectedCharacterModel == null
                ? _testingCharacterModel.SomersaultParameters
                : _injectedCharacterModel.SomersaultParameters;

            Container.Bind<ISomersaultAvailableChecker>().To<SomersaultAvailableChecker>().FromNew().AsSingle()
                .NonLazy();
            Container.BindInterfacesTo<SomersaultParameters>().FromInstance(parameters).AsSingle().NonLazy();
            Container.BindInterfacesTo<CharacterSomersaultByAnimation>().FromNew().AsSingle().NonLazy();
        }

        protected virtual void BindJumping()
        {
            if (_injectedCharacterModel == null)
                Container.BindInterfacesTo<JumpingParameters>().FromInstance(_testingCharacterModel.JumpingParameters).AsSingle().NonLazy();
            else
                Container.BindInterfacesTo<JumpingParameters>().FromInstance(_injectedCharacterModel.JumpingParameters).AsSingle().NonLazy();

            Container.BindInterfacesTo<JumpingAudioFx>().FromNew().AsSingle().WithArguments(_jumpingFx, _landingFx).NonLazy();
            Container.Bind<IJumpAvailableChecker>().To<JumpAvailableChecker>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesTo<JumpingAddForce>().FromNew().AsSingle().NonLazy();
        }

        protected virtual void BindMovement()
        {
            if (_injectedCharacterModel == null)
                Container.BindInterfacesTo<MovementParameters>().FromInstance(_testingCharacterModel.MovementParameters).AsSingle().NonLazy();
            else
                Container.BindInterfacesTo<MovementParameters>().FromInstance(_injectedCharacterModel.MovementParameters).AsSingle().NonLazy();

            Container.Bind<IMovementAvailableChecker>().To<MovementAvailableChecker>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesTo<CharacterMovement>().FromNew().AsSingle().NonLazy();
        }


        private void OnDrawGizmos()
        {
            if (_hitBoxCollider != null && _rigidbody != null)
            {
                Transform origin = _rigidbody.transform;
                float hitBoxHeight = _hitBoxCollider.size.y;

                Gizmos.color = Color.green;
                
                Vector3 noHitPoint = origin.position + origin.up * (hitBoxHeight * _notHitZonePercent);
                Vector3 secondPoint = noHitPoint + origin.right * 0.5f;
                Gizmos.DrawLine(noHitPoint, secondPoint);

                
                Gizmos.color = Color.red;
                Vector3 legsPoint = origin.position + origin.up * (hitBoxHeight * _legsPercentHeight);
                secondPoint = legsPoint + origin.right * 0.5f;
                Gizmos.DrawLine(legsPoint, secondPoint);

                
                Vector3 bodyPoint = origin.position + origin.up * (hitBoxHeight * _bodyPercentHeight);
                secondPoint = bodyPoint + origin.right * 0.5f;
                Gizmos.DrawLine(bodyPoint, secondPoint);
            }
        }
    }
}
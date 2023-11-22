using UnityEngine;

namespace Characters.Flying.Wings
{
    public class WingsAnimationByAnimator : IWingsAnimation
    {
        private const string CLOSE_WINGS_TRIGGER_PARAMETER = "close";

        private readonly GameObject _wingsRoot;
        private readonly Animator _animator;
        private readonly IWingsAnimationEvents _events;

        public WingsAnimationByAnimator(GameObject wingsRoot, Animator animator, IWingsAnimationEvents events)
        {
            _wingsRoot = wingsRoot;
            _animator = animator;
            _events = events;
        }

        void IWingsAnimation.PlayOpen()
        {
            _wingsRoot.SetActive(true);
        }

        void IWingsAnimation.PlayClose()
        {
            _animator.SetTrigger(CLOSE_WINGS_TRIGGER_PARAMETER);
        }

        public void Initialize()
        {
            _events.OnClosedWings += OnClosedWings;
        }

        private void OnClosedWings()
        {
            Debug.Log("Hide wings");
            _wingsRoot.SetActive(false);
        }

        public void Dispose()
        {
            _events.OnClosedWings -= OnClosedWings;
        }
    }
}
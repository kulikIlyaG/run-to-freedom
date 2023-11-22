using System;
using UnityEngine;

namespace Characters.Flying.Wings
{
    public class WingsAnimationEvents : MonoBehaviour, IWingsAnimationEvents
    {
        public event Action OnOpenedWings;
        public event Action OnSwing;
        public event Action OnBeginCloseWings;
        public event Action OnClosedWings;

        public void RaiseOnOpenedWings()
        {
            Debug.Log("Opened wings");
            OnOpenedWings?.Invoke();
        }

        public void RaiseOnSwing()
        {
            OnSwing?.Invoke();
        }

        public void RaiseOnBeginCloseWings()
        {
            OnBeginCloseWings?.Invoke();
        }

        public void RaiseOnClosedWings()
        {
            Debug.Log("Closed wings");
            OnClosedWings?.Invoke();
        }
    }
}
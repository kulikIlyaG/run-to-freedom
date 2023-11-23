using UnityEngine;

namespace Root.Systems.GamePlayInput.Touch
{
    public class TouchScreenJoystick : IAxisUIControllerExecutor
    {
        private Vector2 _axis = Vector2.zero;

        private Vector2 _startTouchPoint;
        private Vector2 _touchDelta;

        Vector2 IAxisUIControllerExecutor.Axis => _axis;

        public void Tick()
        {
#if UNITY_EDITOR
            MouseLogic();
#else
            TouchScreenLogic();
#endif
        }

#if UNITY_EDITOR
        private void MouseLogic()
        {
            int mouseKey = 0;

            if (Input.GetMouseButtonDown(mouseKey))
            {
                _startTouchPoint = Input.mousePosition;
                _axis = Vector2.zero;
            }
            else if (Input.GetMouseButton(mouseKey))
            {
                _touchDelta = (Vector2) Input.mousePosition - _startTouchPoint;
                Vector2 normalized = _touchDelta.normalized;
                _axis = normalized;
            }
            else if (Input.GetMouseButtonUp(mouseKey))
            {
                _touchDelta = Vector2.zero;
                _axis = Vector2.zero;
            }
        }
#else
        private void TouchScreenLogic()
        {
            if (Input.touchCount > 0)
            {
                UnityEngine.Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _startTouchPoint = touch.position;
                    _axis = Vector2.zero;
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    _touchDelta = touch.position - _startTouchPoint;

                    Vector2 normalizedTouchDelta = _touchDelta.normalized;
                    _axis = normalizedTouchDelta;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    _touchDelta = Vector2.zero;
                    _axis = Vector2.zero;
                }
            }
        }
#endif
    }
}
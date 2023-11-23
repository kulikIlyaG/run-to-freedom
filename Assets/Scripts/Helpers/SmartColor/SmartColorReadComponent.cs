using UnityEngine;

namespace SmartColor
{
    public abstract class SmartColorReadComponent : MonoBehaviour
    {
        [SerializeField] private ColorDataSO _colorData;

        private ISmartColorReadOnly _smartColor;
        
        public void SetColorSO(ColorDataSO color)
        {
            _colorData = color;
        }
        
        private void Awake()
        {
            _smartColor = _colorData;
        }

        private void OnEnable()
        {
            _smartColor.OnChanged += OnChangedColor;
        }

        private void OnDisable()
        {
            _smartColor.OnChanged -= OnChangedColor;
        }

        private void OnChangedColor(Color obj)
        {
            SetColor(obj);
        }

        protected abstract void SetColor(Color color);

        [ContextMenu("Update color")]
        public void UpdateColor()
        {
            SetColor(_colorData.Value);
        }

        protected virtual void OnValidate()
        {
            if (_colorData != null)
            {
                UpdateColor();
            }
        }
    }
}
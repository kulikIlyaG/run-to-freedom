using System;
using UnityEngine;

namespace SmartColor
{
    [Serializable]
    public class ColorData : ISmartColor
    {
        [SerializeField] private Color _value = Color.white;

        public Color Value => _value;
        
        public event Action<Color> OnChanged;
        
        public void SetColor(Color value)
        {
            _value = value;
            OnChanged?.Invoke(_value);
        }
    }
}
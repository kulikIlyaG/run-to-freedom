using System;
using UnityEngine;

namespace SmartColor
{
    [CreateAssetMenu(menuName = "Smart Color", fileName = "Smart Color")]
    public class ColorDataSO : ScriptableObject, ISmartColor
    {
        [SerializeField] private ColorData _colorData;
        
        public Color Value => _colorData.Value;
        
        public event Action<Color> OnChanged;

        public void SetColor(Color value)
        {
            _colorData.SetColor(value);
            
            OnChanged?.Invoke(value);
        }
    }
}
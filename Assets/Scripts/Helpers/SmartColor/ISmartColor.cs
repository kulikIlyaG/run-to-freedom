using UnityEngine;

namespace SmartColor
{
    
    /// <summary>
    /// Эта штука была сделана и удобна как инструмент лвл диза
    /// Она могла бы быть еще удобнее, но то что мне от нее нужно было, а это быстрое управление цветами. она делала
    /// </summary>
    public interface ISmartColor : ISmartColorReadOnly
    {
        void SetColor(Color value);
    }
}
using UnityEngine;

namespace SmartColor
{
    public interface ISmartColor : ISmartColorReadOnly
    {
        void SetColor(Color value);
    }
}
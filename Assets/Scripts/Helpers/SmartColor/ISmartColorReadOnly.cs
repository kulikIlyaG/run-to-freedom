
using System;
using UnityEngine;

namespace SmartColor
{
    public interface ISmartColorReadOnly
    {
        Color Value { get; }
        event Action<Color> OnChanged;
    }
}
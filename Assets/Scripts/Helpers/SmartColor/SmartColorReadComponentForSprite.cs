using UnityEngine;

namespace SmartColor
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SmartColorReadComponentForSprite : SmartColorReadComponent
    {
        [SerializeField] private SpriteRenderer _renderer;
        
        protected override void OnValidate()
        {
            if (_renderer == null)
            {
                _renderer = GetComponent<SpriteRenderer>();
            }
            
            base.OnValidate();
        }

        protected override void SetColor(Color color)
        {
            _renderer.color = color;
        }
    }
}
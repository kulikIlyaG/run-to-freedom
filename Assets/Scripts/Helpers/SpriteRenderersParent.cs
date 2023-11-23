using System;
using SmartColor;
using Unity.VisualScripting;
using UnityEngine;

namespace Base
{
    public class SpriteRenderersParent : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] _renderers;
        [SerializeField] private ColorDataSO _color;

        [SerializeField] private string _sortingLayer;
        [SerializeField] private int _sortingOrder;

        private void Awake()
        {
            UpdateParameters();
        }

        private void OnValidate()
        {
            _renderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
            
            UpdateParameters();
            
            if (_color != null)
            {
                foreach (SpriteRenderer renderer in _renderers)
                {
                    var smartColorReader = renderer.GetComponent<SmartColorReadComponent>();
                    if (smartColorReader != null)
                    {
                        smartColorReader.SetColorSO(_color);
                        smartColorReader.UpdateColor();
                    }
                }
            }
        }

        [ContextMenu("UpdateParameters")]
        private void UpdateParameters()
        {
            foreach (SpriteRenderer renderer in _renderers)
            {
                renderer.sortingLayerName = _sortingLayer;
                renderer.sortingOrder = _sortingOrder;

                if (_color != null)
                {
                    renderer.color = _color.Value;
                }
            }
        }
    }
}
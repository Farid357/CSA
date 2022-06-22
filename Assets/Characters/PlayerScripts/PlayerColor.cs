using System;
using UnityEngine;
using GameSaveTools;

namespace GameLogic
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class PlayerColor : MonoBehaviour
    {
        private SpriteRenderer _sprite;
        private const string ColorKey = "PlayerColorKey";

        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }
        private void OnEnable()
        {
            TrySet();
        }
        private void TrySet()
        {
            var colorData = new ColorData();
            if (colorData.HaveKey(ColorKey))
            {
                Color lastSelectColor = colorData.LoadColor(ColorKey);
                _sprite.color = lastSelectColor;
            }
            else
                throw new NullReferenceException("Exist key!");
        }
        public void Set(Color color)
        {
            _sprite.color = color;
        }
    }
}

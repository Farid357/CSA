using UnityEngine;
using UnityEngine.UI;
using GameSaveTools;

namespace GameLogic
{

    public sealed class PlayerColorSelector : MonoBehaviour
    {
        [SerializeField] private PlayerColor _playerColor;
        [SerializeField] private Image _image;
        private const string ColorKey = "PlayerColorKey";

        public void OnClick()
        {
            _playerColor.Set(_image.color);
            ColorSaver.Save(_image.color, ColorKey);
        }
    }
}

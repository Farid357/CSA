using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{
    [RequireComponent(typeof(Button))]
    public sealed class BuyingButton : MonoBehaviour
    {
        public PlayerModelData Data { get; private set; }
        public int Index { get; private set; }
        private Button _button;

        private void OnEnable()
        {
            _button = GetComponent<Button>();
        }

        public void Init(PlayerModelData data, int index)
        {
            Data = data;
            Index = index;
            _button.interactable = data.IsPurchased ? true : false;
        }
    }
}

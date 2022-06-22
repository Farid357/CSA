using UnityEngine;
using TMPro;

namespace GameLogic
{
    public sealed class PlayerStatsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _damageText;
        [SerializeField] private TextMeshProUGUI _costText;

        public void Display(PlayerModelData model)
        {
            _healthText.text = $"Health: {model.Health}";
            _damageText.text = $"Damage: {model.Damage}";
            _costText.text = $"Cost: {model.Cost}";
        }
    }
}

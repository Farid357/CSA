using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{

    public sealed class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private Image _bar;
        [SerializeField] private ObjectHealth _player;

        private Color _startColor;

        private void OnEnable()
        {
            _player.OnHealthChanged += Display;
            _startColor = _bar.color;
            EnergyShield.OnCollect += SetNewColor;
            EnergyShield.OnEnd += SetStartColor;
        }

        private void OnDisable()
        {
            _player.OnHealthChanged -= Display;
            EnergyShield.OnCollect -= SetNewColor;
            EnergyShield.OnEnd -= SetStartColor;
        }

        private void Display(int health)
        {
            _bar.fillAmount = health * 0.001f;
        }
        private void SetStartColor()
        {
            _bar.color = _startColor;
        }
        private void SetNewColor()
        {
            _bar.color = Color.blue;
        }
    }

}

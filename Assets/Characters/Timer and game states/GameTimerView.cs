using TMPro;
using UnityEngine;

namespace GameLogic
{
    public sealed class GameTimerView : MonoBehaviour
    {
        [SerializeField] private GameObject _panelTimer;
        [SerializeField] private GameStartTimer _timer;
        [SerializeField] private TextMeshProUGUI _timerText;
        private void OnEnable()
        {
            _timer.OnChanged += Display;
        }
        private void OnDisable()
        {
            _timer.OnChanged -= Display;

        }
        private void Display()
        {
            _timerText.text = _timer.WaitTime.ToString();
            TryDisableTimer();
        }
        private void TryDisableTimer()
        {
            if (_timer.WaitTime == 0)
                _panelTimer.SetActive(false);
        }
    }
}

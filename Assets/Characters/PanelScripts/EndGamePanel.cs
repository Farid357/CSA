using TMPro;
using UnityEngine;

namespace GameLogic
{
    public sealed class EndGamePanel : MonoBehaviour
    {
        [SerializeField] private AudioSource _music;
        [SerializeField] private EnemyWaves _wawes;
        [SerializeField] private PlayerDestruction _player;
        [SerializeField] private GameState _gameState;

        [SerializeField] private GameObject _panel;
        [SerializeField] private TextMeshProUGUI _endText;

        private void Start()
        {
            _wawes.OnWin += On;
            _player.OnLose += On;
        }

        private void OnDestroy()
        {
            _wawes.OnWin -= On;
            _player.OnLose -= On;
        }

        public void On(string endText)
        {
            _music.Stop();
            _panel.SetActive(true);
            _endText.text = endText;
            _gameState.Pause();
        }

        public void Off()
        {
            _panel.SetActive(false);
        }
    }
}

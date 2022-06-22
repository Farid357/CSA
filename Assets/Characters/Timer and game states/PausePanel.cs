using UnityEngine;

namespace GameLogic
{
    public sealed class PausePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameState _gameState;

        public void On()
        {
            _pausePanel.SetActive(true);
            _gameState.Pause();
        }
        public void Off()
        {
            _pausePanel.SetActive(false);
            _gameState.Continue();
        }
        private void OnApplicationPause(bool pause)
        {
            if(pause)
            On();
        }
    }
}

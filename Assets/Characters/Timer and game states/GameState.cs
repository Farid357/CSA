using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public sealed class GameState : MonoBehaviour
    {
        public bool IsPaused => _isPaused;

        private bool _isPaused;
        public void Pause()
        {
            SetPause(true, 0);
        }
        public void Continue()
        {
            SetPause(false);
        }
        public void Resume()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        private void SetPause(bool isPaused, int timeScale = 1)
        {
            _isPaused = isPaused;
            Time.timeScale = timeScale;
        }
    }
}

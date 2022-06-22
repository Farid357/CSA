using TMPro;
using UnityEngine;

namespace GameLogic
{
    public sealed class ScoreView : MonoBehaviour
    {
        [SerializeField] private ScoreCollector _score;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private void OnEnable() => _score.OnCollect += Display;
        private void OnDisable() => _score.OnCollect -= Display;

        private void Display(int value)
        {
            _scoreText.text = value.ToString();
        }
    }
}

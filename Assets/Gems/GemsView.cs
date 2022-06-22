using TMPro;
using UnityEngine;

namespace GameLogic
{
    public sealed class GemsView : MonoBehaviour
    {
        [SerializeField] private GemsCollector _collector;
        [SerializeField] private TextMeshProUGUI _gemsText;

        private void OnEnable()
        {
            _collector.OnChanged += Display;
            _gemsText.text = _collector.GetCount().ToString();
        }

        private void OnDisable() => _collector.OnChanged -= Display;

        private void Display()
        {
            _gemsText.text = _collector.GemsCount.ToString();
        }
    }
}

using UnityEngine;
using TMPro;

namespace GameLogic
{
    public sealed class MusicVolume : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _volumeText;
        private const string Key = "Volume";

        public void OnMoveSlider(float volume)
        {
            PlayerPrefs.SetFloat(Key, volume);
            _volumeText.text = $"{Mathf.RoundToInt( volume * 100f)}%";
        }
        public static float Load()
        {
            if(PlayerPrefs.HasKey(Key))
            return PlayerPrefs.GetFloat(Key);
            return 1;
        }
    }
}

using UnityEngine;

namespace GameLogic
{
    public sealed class MusicVolumeReciever : MonoBehaviour
    {
        private AudioSource _music;

        private void Start()
        {
            _music = GetComponent<AudioSource>();
            _music.volume = MusicVolume.Load();
        }
    }
}

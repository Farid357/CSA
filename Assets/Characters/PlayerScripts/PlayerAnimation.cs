using System.Collections;
using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(Animation))]
    public sealed class PlayerAnimation : MonoBehaviour
    {
        private PlayerMovement _player;
        private Animation _animation;

        private void Start()
        {
            _player = GetComponent<PlayerMovement>();
            _animation = GetComponent<Animation>();
            StartCoroutine(Play());
        }
        private IEnumerator Play()
        {
            _player.Stop();
            _animation.Play();
            while (_animation.isPlaying)
            {
                yield return null;
            }
            _animation.Stop();
            _player.Restart();
        }
    }
}

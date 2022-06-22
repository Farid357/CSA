using UnityEngine;
using System;

namespace GameLogic
{
    [RequireComponent(typeof(ObjectHealth))]
    public sealed class PlayerDestruction : MonoBehaviour, IDestruction
    {
        public event Action<string> OnLose;

        private ObjectHealth _player;
        private const string LoseText = "You lose!";

        private void Awake()
        {
            _player = GetComponent<ObjectHealth>();
        }
        private void OnEnable() => _player.OnEnd += Destroy;

        private void OnDestroy() => _player.OnEnd -= Destroy;

        public void Destroy()
        {
            OnLose?.Invoke(LoseText);
            gameObject.SetActive(false);
        }
    }
    public interface IDestruction
    {
        public void Destroy();
    }

}

using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic
{
    public sealed class GameStartTimer : MonoBehaviour
    {
        public int WaitTime => _waitTime;
        public event Action OnChanged;

        [SerializeField] private GameState _gameState;

        private const int _delay = 1;
        private  int _waitTime = 4;

        private void Update()
        {
            if (_waitTime >= 0)
            {
                Enable();
            }
        }

        private async void Enable()
        {
            if (_waitTime >= 0)
            {       
                _gameState.Pause();
                await Task.Delay(_delay * 1050);
                _waitTime--;
                OnChanged?.Invoke();

                if(_waitTime >= 0)
                return;
            }
            _gameState.Continue();
        }
        
    }
}

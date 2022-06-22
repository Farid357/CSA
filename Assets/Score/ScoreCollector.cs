using UnityEngine;
using System;

namespace GameLogic
{
    public sealed class ScoreCollector : MonoBehaviour
    {
        public event Action<int> OnCollect;
        
        private int _scoreCount;

        private void FixedUpdate()
        {
            Add(1);
        }
        public void Add(int scoreCount)
        {
            _scoreCount += scoreCount;
            OnCollect?.Invoke(_scoreCount);
        }
    }
}

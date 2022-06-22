using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public sealed class EnemyWaves : MonoBehaviour
    {
        public event Action<string> OnWin;
        [SerializeField] private LevelData _level;
        [SerializeField] private EnemyGenerator _generator;

        private int _indexWave;
        private int _indexEnemy;

        private WaitForSeconds _duration;
        private const string WinText = "You win!";

        private void Start()
        {
            _duration = new WaitForSeconds(2f);

            Activate();
        }
        
        public void Activate()
        {
            StartCoroutine(EnemyActivate());
        }

        private IEnumerator EnemyActivate()
        {
            var count = _level.Waves[_indexWave].CountInWave;

            while (count > 0)
            {
                _generator.Generate(_level.Waves[_indexWave]);
                count--;
                 _generator.Enemies[_indexEnemy].gameObject.SetActive(true);
                _indexEnemy++;
                yield return _duration;
            }
            if (_indexWave == _level.Waves.Count - 1 && count <= 0)
            {
                OnWin.Invoke(WinText);
            }

            if (_indexWave < _level.Waves.Count - 1)
            {
                Invoke(nameof(Activate), _level.Waves[_indexWave].WaitAfterWave);
                _indexWave++;
            }

        }
    }
}

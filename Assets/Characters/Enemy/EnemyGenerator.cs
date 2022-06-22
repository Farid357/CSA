using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public sealed class EnemyGenerator : MonoBehaviour
    {
        public List<GameObject> Enemies => _enemies;
        [SerializeField] private LevelData _level;

        private readonly List<GameObject> _enemies = new List<GameObject>();

        public void Generate(Wave wave)
        {
            for (int i = 0; i < wave.CountInWave; i++)
            {
                GameObject enemy = Instantiate(wave.EnemyPrefab, transform);
                enemy.SetActive(false);
                _enemies.Add(enemy);
            }
        }
    }
}

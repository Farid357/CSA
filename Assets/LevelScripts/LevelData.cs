using UnityEngine;
using System;
using System.Collections.Generic;

namespace GameLogic
{
    [CreateAssetMenu(fileName = "Level", menuName = "Game/Level")]
    public sealed class LevelData : ScriptableObject
    {
        public List<Wave> Waves => _waves;

        [SerializeField] private List<Wave> _waves = new List<Wave>();
    }
    [Serializable]
    public class Wave
    {
        public int CountInWave => _countInWave;

        public GameObject EnemyPrefab => _enemyPrefab;
        public float WaitAfterWave => _waitAfterWave;
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField, Min(0)] private int _countInWave;
        [SerializeField, Min(0)] private float _waitAfterWave;
    }
}

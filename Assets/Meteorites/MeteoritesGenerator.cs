using System.Collections;
using UnityEngine;

namespace GameLogic
{
    public sealed class MeteoritesGenerator : MonoBehaviour
    {
        [SerializeField] private MeteoritesPool _pool;
        [SerializeField] private GameObject _meteoritePrefab;
        [SerializeField] private int _addCount = 10;
        [SerializeField] private int _waitTime = 5;

        private WaitForSeconds _wait;

        private void Start()
        {
            _wait = new WaitForSeconds(_waitTime);
            _pool.Add(_meteoritePrefab, _addCount);
            StartCoroutine(TryGenerate());
        }
        private IEnumerator TryGenerate()
        {
            while(true)
            {
                if (_pool.HaveMeteorite)
                {
                    var meteorite = _pool.GetMeteorite();
                    Enable(meteorite);
                    yield return _wait;
                }
                else
                {
                    _pool.Add(_meteoritePrefab, _addCount);
                    var meteorite = _pool.GetMeteorite();
                    Enable(meteorite);
                    yield return null;
                }
            }
        }
        private void Enable(GameObject prefab)
        {
            prefab.SetActive(true);
        }
    }
}

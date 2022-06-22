using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public sealed class MeteoritesPool : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;
        private readonly List<GameObject> _meteorites = new List<GameObject>();

       public void Add(GameObject prefab, int count)
        {
            if (prefab == null)
                throw new NullReferenceException("Prefab is null!");
            for (int i = 0; i < count; i++)
            {
                var randomIndex = UnityEngine.Random.Range(0, _points.Length);
                var randomPosition = _points[randomIndex];
                var meteorite = Instantiate(prefab, randomPosition.position, Quaternion.identity);
                meteorite.SetActive(false);
                _meteorites.Add(meteorite);
            }
        }
        public GameObject GetMeteorite()
        {
            foreach (var meteorite in _meteorites)
            {
                if(!meteorite.activeInHierarchy)
                {
                    return meteorite;
                }
                if (_meteorites.Count == 0)
                    throw new InvalidOperationException("Pool count is 0!");
            }
            return null;
        }
        public bool HaveMeteorite
        {
            get
            {
                foreach (var meteorite in _meteorites)
                {
                    if (!meteorite.activeInHierarchy && _meteorites.Count != 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public sealed class BulletsPool : MonoBehaviour
    {
        private readonly Dictionary<string, List<GameObject>> _bullets = new Dictionary<string, List<GameObject>>();
       public void Add(GameObject bulletPrefab, int count)
        {
            if (!_bullets.ContainsKey(bulletPrefab.name))
                _bullets.Add(bulletPrefab.name, new List<GameObject>());
            for (int i = 0; i < count; i++)
            {
                Create(bulletPrefab);
            }
        }

        private GameObject Create(GameObject bulletPrefab)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.SetActive(false);
            _bullets[bulletPrefab.name].Add(bullet);


            return bullet;
        }

        public GameObject GetBullet(GameObject bulletPrefab)
        {
            if (_bullets.ContainsKey(bulletPrefab.name))
            {
                for (int i = 0; i < _bullets[bulletPrefab.name].Count - 1; i++)
                {
                    if (!_bullets[bulletPrefab.name][i].activeInHierarchy)
                        return _bullets[bulletPrefab.name][i];
                }
                return Create(bulletPrefab);
            }
            else
            {
                _bullets.Add(bulletPrefab.name, new List<GameObject>());

            }
            return Create(bulletPrefab);
        }
    }
}

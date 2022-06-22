using System.Collections;
using UnityEngine;

namespace GameLogic
{
    public abstract class PlayerCannon : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _bulletsCount = 6;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private float _shotTimer = 0.5f;
        [SerializeField] private bool _isPlayer;
        protected BulletsPool _bulletsPool;

        private WaitForSeconds _wait;

        private void OnEnable()
        {
            if (_bulletsPool == null)
            {
                _bulletsPool = FindObjectOfType<BulletsPool>();
            }
            if (_bulletsCount > 0)
            {
                _bulletsPool.Add(_bullet, _bulletsCount);
            }
            _wait = new WaitForSeconds(_shotTimer);
            if(_isPlayer)
            StartCoroutine(StartTimer());
        }
        private IEnumerator StartTimer()
        {
            while (true)
            {
                Shot();
                yield return _wait;
            }
        }
        protected void BulletActivate(Transform bulletStartPosition)
        {
            var bullet = _bulletsPool.GetBullet(_bullet);
            bullet.transform.position = bulletStartPosition.position;
            bullet.SetActive(true);
        }
        public abstract void Shot();
    }
}

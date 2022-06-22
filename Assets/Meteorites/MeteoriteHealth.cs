using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic
{
    public sealed class MeteoriteHealth : MonoBehaviour, IDamagable, IDestruction
    {
        [SerializeField] private UnityEvent OnDied;
        [SerializeField, Min(0)] private int _health = 90;
        [SerializeField] private ParticleSystem _particlePrefab;

        public void Destroy()
        {
            OnDied?.Invoke();
            gameObject.SetActive(false);
            var particle = CreateEffect(transform.position, Quaternion.identity);
            particle.Play();
            Destroy(particle, 2);
        }

        private ParticleSystem CreateEffect(Vector3 position, Quaternion quaternion)
        {
            return Instantiate(_particlePrefab, position, quaternion);
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Destroy();
            }
        }
    }
}

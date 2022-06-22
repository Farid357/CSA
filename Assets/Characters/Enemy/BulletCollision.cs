using System;
using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(CapsuleCollider2D))]
    public sealed class BulletCollision : MonoBehaviour
    {

        public int Damage
        {
            get => _damage; 
            set 
            {
                if (value <= 0)
                    throw new InvalidOperationException("Damage is below 0");
                _damage = value; 
            }
        }

        [SerializeField, Range(100, 2000)] private int _damage = 120;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage(_damage);
            }
            ResetObject();
        }

        private void ResetObject()
        {
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }
    }
}

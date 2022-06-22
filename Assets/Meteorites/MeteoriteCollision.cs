using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(CapsuleCollider2D))]
    public sealed class MeteoriteCollision : MonoBehaviour
    {
        [SerializeField] private int _damage = 1000;
        
        private const int Speed = 3;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out ObjectHealth player))
            {
                player.TakeDamage(_damage);
                Disable();
            }
            if(collision.TryGetComponent(out EnergyShield shield))
            {
                Disable();
            }
        }
        private void Update()
        {
            Move(Vector2.down);
        }
        private void Move(Vector2 direction)
        {
            transform.Translate(direction * Speed * Time.deltaTime);
            TryDisable();
        }
        private void TryDisable()
        {
            if(transform.position.y < -12)
            {
                Disable();
            }
        }
        private void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}

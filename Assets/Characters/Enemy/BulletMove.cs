using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class BulletMove : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _speed = 14f;
        [SerializeField] private bool _isEnemy;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

        }
        private void FixedUpdate()
        {
            if(!_isEnemy)
            _rigidbody.velocity = transform.up * _speed;
            else
                _rigidbody.velocity = -transform.up * _speed;
        }
    }
}

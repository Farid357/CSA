using UnityEngine;

namespace GameLogic
{
    public sealed class Speedometer : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _player;
        [SerializeField] private GameObject _arrow;

        [SerializeField] private float _minEulerAngle;
        [SerializeField] private float _maxEulerAngle;
        [SerializeField] private float _maxSpeed;
        
        public float _speed;
        private const float CofficientToKm = 3.6f;

        private void Update()
        {
            _speed = _player.velocity.magnitude * CofficientToKm;
            Rotate(_arrow.transform);
        }
        private void Rotate(Transform arrow)
        {
            arrow.localEulerAngles = new Vector3(0,0, Mathf.Lerp(_minEulerAngle, _maxEulerAngle, _speed / _maxSpeed));
        }

    }
}

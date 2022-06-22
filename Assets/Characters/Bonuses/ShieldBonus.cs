using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(CapsuleCollider2D))]
    public sealed class ShieldBonus : BonusMovement
    {

        [SerializeField] private EnergyShield _shieldPrefab;
        [SerializeField] private ObjectHealth _player;

        private static EnergyShield _currentShield;

        private void CheckShield()
        {
            if (_currentShield == null)
                _currentShield = Instantiate(_shieldPrefab);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out _player))
            {
                CheckShield();
                _currentShield.transform.SetParent(_player.transform);
                _currentShield.transform.position = _player.transform.position;

                _currentShield.Show();
                gameObject.SetActive(false);
            }
        }
    }
}

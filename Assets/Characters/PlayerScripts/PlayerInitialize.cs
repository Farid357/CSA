using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(ObjectHealth))]
    public sealed class PlayerInitialize : MonoBehaviour
    {
        [SerializeField] private PlayerModelsData _data;
        [SerializeField] private BulletCollision _bullet;
        private ObjectHealth _health;

        private void Awake()
        {
            var modelData = _data.Load();
            _health = GetComponent<ObjectHealth>();
            _health.CurrentHealth = modelData.Health;
            _bullet.Damage = modelData.Damage;
        }
    }
}

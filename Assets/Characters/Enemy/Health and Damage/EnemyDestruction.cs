using UnityEngine;
using UnityEngine.Events;

namespace GameLogic
{
    [RequireComponent(typeof(ObjectHealth))]
    public sealed class EnemyDestruction : MonoBehaviour, IDestruction
    {
        [SerializeField] private UnityEvent OnDied;
        [SerializeField] private ObjectHealth _enemy;

        private void OnEnable() => _enemy.OnEnd += Destroy;

        private void OnDestroy() => _enemy.OnEnd -= Destroy;
     
        public void Destroy()
        {
            OnDied.Invoke();
            Destroy(gameObject);
        }
    }
}

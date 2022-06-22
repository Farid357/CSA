using UnityEngine;
using System;

namespace GameLogic
{
    public class ObjectHealth : MonoBehaviour, IDamagable
    {
        public event Action OnEnd;
        public event Action<int> OnHealthChanged;

        public int CurrentHealth { private get; set; }

        private void Start()
        {
            OnHealthChanged?.Invoke(CurrentHealth);
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnEnd?.Invoke();
            }
            OnHealthChanged?.Invoke(CurrentHealth);
        }
        public void Hill(int value)
        {
            CurrentHealth += value;
            OnHealthChanged?.Invoke(CurrentHealth);
        }
    }
}

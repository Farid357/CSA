using System;
using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(CapsuleCollider2D))]
    public sealed class HealthBonus : BonusMovement
    {
        [SerializeField] private int _health;
        
        [SerializeField] private ObjectHealth _player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out _player))
            {
                _player.Hill(_health);
                gameObject.SetActive(false);
            }
        }

    }
}

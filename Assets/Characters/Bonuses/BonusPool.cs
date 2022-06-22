using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic
{
    public sealed class BonusPool : MonoBehaviour
    {
        public static BonusPool Instance => _instance;
        private static BonusPool _instance;
        public List<BonusMovement> Bonuses => _bonuses;
        private readonly  List<BonusMovement> _bonuses = new List<BonusMovement>();

        private void Awake()
        {
            _instance = this;
        }
        public void Add(BonusMovement bonusPrefab, int count, Transform target)
        {
            for (int i = 0; i < count; i++)
            {
                var bonus = Instantiate(bonusPrefab, target.position, Quaternion.identity);
                _bonuses.Add(bonusPrefab);
                bonus.gameObject.SetActive(false);
            }
        }
        public BonusMovement GetBonus(BonusMovement bonus)
        {
            for (int i = 0; i < _bonuses.Count; i++)
            {
                if (!bonus.gameObject.activeInHierarchy)
                { 
                    return _bonuses[i];
                }
            }
            return null;
        }
        public bool HaveBonus(BonusMovement bonus)
        {
            if (_bonuses.Contains(bonus))
            {
                return true;
            }
            return false;
        }
    }
}

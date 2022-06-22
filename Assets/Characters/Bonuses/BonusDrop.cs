using System;
using UnityEngine;

namespace GameLogic
{
    public sealed class BonusDrop : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _minChance = 3;
        [SerializeField, Min(1)] private int _count = 5;

        [SerializeField] private BonusesData _bonusesData;

        private int _maxChance;

        public void TryGenerate()
        {
            if (BonusPool.Instance.Bonuses == null)
                throw new NullReferenceException("Pool bonuses is null!");
            _maxChance = Caluclate();
            int chance = UnityEngine.Random.Range(_minChance, _maxChance);

            for (int i = 0; i < _bonusesData.Bonuses.Count; i++)
            {
                if (chance == _bonusesData.Bonuses[i].Chance)
                {
                    var bonus = _bonusesData.Bonuses[i];
                    Generate(bonus);
                    break;
                }
            }
          

        }
        private int Caluclate()
        {
            _maxChance = 0;
            foreach (var bonus in _bonusesData.Bonuses)
            {
                _maxChance += bonus.Chance;
            }
            return _maxChance;
        }
        private void Generate(BonusMovement bonusPrefab)
        {
            if (bonusPrefab == null)
                throw new NullReferenceException("BonusPrefab is null!");
            if(BonusPool.Instance.HaveBonus(bonusPrefab))
            {
                var bonus = BonusPool.Instance.GetBonus(bonusPrefab);
                bonus.transform.position = transform.position;
                bonus.gameObject.SetActive(true);
            }
            else
            {
                var bonus = Instantiate(bonusPrefab, transform.position, Quaternion.identity);
                bonus.gameObject.SetActive(true);
                BonusPool.Instance.Add(bonusPrefab, _count, transform);
 
            }
        }
    }
}

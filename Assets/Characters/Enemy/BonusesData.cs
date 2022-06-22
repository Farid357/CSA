using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    [CreateAssetMenu(fileName = "BonusesDataSO", menuName = "BonusesDataSO")]
    public sealed class BonusesData : ScriptableObject
    {
        public List<BonusMovement> Bonuses => _bonuses;

        [SerializeField] private List<BonusMovement> _bonuses = new List<BonusMovement>();
    }
}

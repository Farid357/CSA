using UnityEngine;

namespace GameLogic
{
    [CreateAssetMenu(fileName = "Model", menuName = "PlayerModel")]
    public sealed class PlayerModelData : ScriptableObject
    {
        public int Index => _index;
        public bool IsPurchased = false;
        public int Cost => _cost;
        public int Health => _health;
        public int Damage => _damage;

        [SerializeField, Min(0)] private int _health;
        [SerializeField, Min(0)] private int _damage;
        [SerializeField, Min(0)] private int _cost;
        [SerializeField, Range(0, 20)] private int _index;
    }
}

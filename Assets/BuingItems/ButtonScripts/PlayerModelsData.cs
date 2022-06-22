using UnityEngine;

namespace GameLogic
{
    [CreateAssetMenu(fileName = "Model", menuName = "PlayerModelsData")]
    public sealed class PlayerModelsData : ScriptableObject
    {
        [SerializeField] private PlayerModelData[] _models;

        private const string Purchased = "Purchaseddd";
        private const string Id = "Model data d";
        private int _index;

        public PlayerModelData Load()
        {
            _index = PlayerPrefs.GetInt(Id);
            return  _models[_index];
        }
        public void Save(PlayerModelData data, int index)
        {
            PlayerPrefs.SetInt(Purchased, data.IsPurchased ? 0 : 1);
            PlayerPrefs.SetInt(Id, index);
            PlayerPrefs.Save();
        }
    }
}

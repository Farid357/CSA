using UnityEngine;

namespace GameLogic
{
    public sealed class BuyingButtonsGenerator : MonoBehaviour
    {
        [SerializeField] private PlayerModelData[] _models;
        [SerializeField] private Transform _parent;
        [SerializeField] private GameObject _prefab;

        private void Awake()
        {
            Generate();
        }

        private void Generate()
        {

            for (int i = 0; i < _models.Length - 1; i++)
            {
                var button = Instantiate(_prefab, _parent);
                button.GetComponent<BuyingButton>().Init(_models[i], i);
            }
        }
    }
}

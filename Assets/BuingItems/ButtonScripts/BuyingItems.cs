using UnityEngine;
using System;

namespace GameLogic
{
    public sealed class BuyingItems : MonoBehaviour
    {
        public event Action<string> OnBuyed;
        [SerializeField] private GemsCollector _collector;
        [SerializeField] private PlayerModelsData _data;

        public void Buy(PlayerModelData model)
        {
            if (!model.IsPurchased)
            {
                _collector.TryTake(model.Cost);
                _collector.Save();
                model.IsPurchased = true;
                OnBuyed.Invoke("Item purchased!");
                Save(model);
            }
        }
        private void Save(PlayerModelData model)
        {
            _data.Save(model, model.Index);
        }
    }

}

using UnityEngine;
using System;

namespace GameLogic
{
    public sealed class GemsCollector : MonoBehaviour
    {
        public int GemsCount => _gemsCount;
        public event Action OnChanged;

        private int _gemsCount;
        private const int Count = 1;
        private const string GemsKey = "Gems";

        public int GetCount()
        {
            _gemsCount = PlayerPrefs.GetInt(GemsKey, 0);
            OnChanged.Invoke();
            return _gemsCount;
        }
        public void TryTake(int count)
        {
            if (_gemsCount - count >= 0)
            {
                _gemsCount -= count;
                OnChanged.Invoke();
            }
        }

        public void Add()
        {
            _gemsCount += Count;
            Save();
            OnChanged.Invoke();
        }

        public void Save()
        {
            PlayerPrefs.SetInt(GemsKey, _gemsCount);
        }
    }
}

using UnityEngine;
using System.Collections;
using System;

namespace GameLogic
{
    public sealed class EnergyShield : MonoBehaviour
    {
        public static event Action OnCollect;
        public static event Action OnEnd;
        [SerializeField, Min(0)] private  int _waitTime = 30;

        private WaitForSeconds _wait;

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            StartCoroutine(StartTimer());
        }

        private IEnumerator StartTimer()
        {
            OnCollect.Invoke();
            _wait = new WaitForSeconds(_waitTime);
            yield return _wait;
            OnEnd?.Invoke();
            Hide();
        }
    }
}

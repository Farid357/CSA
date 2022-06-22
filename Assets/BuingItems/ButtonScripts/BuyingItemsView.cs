using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace GameLogic
{
    [RequireComponent(typeof(Button))]
    public sealed class BuyingItemsView : MonoBehaviour
    {
        [SerializeField] private BuyingItems _buyingItems;
        [SerializeField] private TextMeshProUGUI _purchasedText;
        [SerializeField] private PlayerModelsData _data;

        private Button _button;
        private WaitForSeconds _wait;

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.interactable = _data.Load();
            _buyingItems.OnBuyed += Show;
            _wait = new WaitForSeconds(1.5f);
        }
        private void OnDisable()
        {
            _buyingItems.OnBuyed -= Show;
        }
        private void Show(string showText)
        {
            StartCoroutine(SetShowText(showText));
        }
        private IEnumerator SetShowText(string showText)
        {
            _purchasedText.gameObject.SetActive(true);
            _purchasedText.text = showText;
            _button.interactable = false;
            yield return _wait;
            _purchasedText.gameObject.SetActive(false);
        }
    }
}

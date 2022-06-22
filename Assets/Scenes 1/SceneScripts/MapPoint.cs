using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CircleCollider2D), typeof(SpriteRenderer))]
public sealed class MapPoint : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent OnClick;

    private int _levelIndex;
    
    public void SetParameters(Sprite sprite, int index)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        _levelIndex = index;

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        LevelNameData levelData = new LevelNameData();
        levelData.SetName("Game");
        levelData.SetLevelIndex(_levelIndex);
        OnClick?.Invoke();
    }
}

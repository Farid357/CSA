using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public sealed class BorderHight : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private const int FullSize = 2;
    private void Awake()
    {
        SetSize();
    }
    private void SetSize()
    {
        float yScale = _camera.ScreenToWorldPoint(Screen.safeArea.max).y * FullSize;
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();

        boxCollider2D.size = new Vector2(boxCollider2D.size.x, yScale);
    }
}

using UnityEngine;

public sealed class BackGround : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private SpriteRenderer _backGround;
    private float _positionMinY;
    private Vector2 _restartPosition;

    private void Awake()
    {
        _restartPosition = transform.position;
        _positionMinY = (_backGround.bounds.size.y * 2) - _restartPosition.y;
    }
    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);

        if(transform.position.y <= -_positionMinY)
        {
            transform.position = _restartPosition;
        }
    }
}

using UnityEngine;
using GameLogic;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public sealed class EnemyMovement : MonoBehaviour
{
    [SerializeField] private UnityEvent OnCheckPoint;
    [SerializeField] private float _speed = 2f;
    
    [SerializeField] private PathData _path;

    private Rigidbody2D _rigidbody;
    private Camera _camera;

    private float _yMinPosition;
    private int _index;

    private void Start()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
        _yMinPosition = _camera.ScreenToViewportPoint(-Screen.safeArea.max).y * 14;
    }
    private void FixedUpdate()
    {
        
       _rigidbody.MovePosition(Vector2.MoveTowards(transform.position, _path.Points[_index], _speed * Time.fixedDeltaTime));
        TryGoNext();
        TryDestroy(gameObject);     
    }
    private void TryDestroy(GameObject gameObject)
    {
        if (transform.position.y < _yMinPosition)
        {
            Destroy(gameObject);
        }
        if(_index > _path.Points.Count - 1)
        {
            Destroy(gameObject);
        }
    }
    private void TryGoNext()
    {
        if (Vector3.Distance(transform.position, _path.Points[_index]) < 1f)
        {
            if (_index < _path.Points.Count - 1)
            {
                OnCheckPoint?.Invoke();
                _index++;
            }
        }
    }
}

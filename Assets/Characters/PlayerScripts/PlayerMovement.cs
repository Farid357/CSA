using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    private Vector2 _direction;

    [SerializeField] private FixedJoystick _joystick;

    private Rigidbody2D _rigidbody;
    private bool _canMove;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (PositionIsChanged && _canMove)
        {
            _direction.x = _joystick.Horizontal;
            _direction.y = _joystick.Vertical;
            Move(_direction);
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
    private bool PositionIsChanged => _joystick.Horizontal != 0 || _joystick.Vertical != 0;
    private void Move(Vector2 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + _speed * Time.fixedDeltaTime * direction);
        _rigidbody.velocity = direction;
    }
    public void Stop()
    {
        _canMove = false;
    }
    public void Restart()
    {
        _canMove = true;
    }
}

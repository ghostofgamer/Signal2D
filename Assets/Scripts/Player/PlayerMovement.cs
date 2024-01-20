using UnityEngine;

[RequireComponent(typeof(GroundChecker), typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _force;

    private SpriteRenderer _spriteRenderer;
    private GroundChecker _groundChecker;
    private PlayerAnimations _playerAnimations;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _groundChecker = GetComponent<GroundChecker>();
        _playerAnimations = GetComponent<PlayerAnimations>();
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        var moveDirection = _playerInput.HorizontalInput();

        if (_groundChecker.GroundCheck)
            _playerAnimations.RunAnimation(moveDirection != 0);

        FlipPlayer(moveDirection < 0f);
        transform.position += new Vector3(moveDirection * _speed * Time.deltaTime, 0);
    }

    private void Jump()
    {
        var playerAnimation = GetComponent<PlayerAnimations>();

        if (_playerInput.JumpInput() && _groundChecker.GroundCheck)
            _rigidbody.AddForce(new Vector2(0, _force));

        playerAnimation.JumpAnimation(!_groundChecker.GroundCheck);
    }

    private void FlipPlayer(bool flag)
    {
        _spriteRenderer.flipX = flag;
    }
}
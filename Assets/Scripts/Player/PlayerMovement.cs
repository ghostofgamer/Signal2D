using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _force;

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        var moveDirection = GetComponent<PlayerInput>().HorizontalInput();

        if (GetComponent<GroundChecker>().GroundCheck)
            GetComponent<PlayerAnimations>().RunAnimation(moveDirection != 0);

        FlipPlayer(moveDirection < 0f);
        transform.position += new Vector3(moveDirection * _speed * Time.deltaTime, 0);
    }

    private void Jump()
    {
        var groundChecker = GetComponent<GroundChecker>().GroundCheck;
        var playerAnimation = GetComponent<PlayerAnimations>();

        if (GetComponent<PlayerInput>().JumpInput() && groundChecker)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, _force));

        playerAnimation.JumpAnimation(!groundChecker);
    }

    private void FlipPlayer(bool flag)
    {
        GetComponent<SpriteRenderer>().flipX = flag;
    }
}

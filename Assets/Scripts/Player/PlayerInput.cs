using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private void Update()
    {
        HorizontalInput();
        JumpInput();
    }

    public float HorizontalInput()
    {
        return Input.GetAxis("Horizontal");
    }

    public bool JumpInput()
    {
        return Input.GetButtonDown("Jump");
    }
}

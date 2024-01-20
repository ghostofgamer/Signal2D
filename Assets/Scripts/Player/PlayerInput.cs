using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    private void Update()
    {
        HorizontalInput();
        JumpInput();
    }

    public float HorizontalInput()
    {
        return Input.GetAxis(Horizontal);
    }

    public bool JumpInput()
    {
        return Input.GetButtonDown(Jump);
    }
}
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool GroundCheck { get; private set; } = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Floor>(out Floor floor))
            GroundCheck = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Floor>(out Floor floor))
            GroundCheck = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSignalization : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            GetComponent<HomeSound>().OnAlarm();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            GetComponent<HomeSound>().OffAlarm();
    }
}

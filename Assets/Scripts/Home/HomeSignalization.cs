using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSignalization : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<HomeSound>().OnAlarm();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<HomeSound>().OffAlarm();
    }
}

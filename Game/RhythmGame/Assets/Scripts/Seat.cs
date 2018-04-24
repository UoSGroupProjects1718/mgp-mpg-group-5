using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public bool taken = false;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "p1Customer" || collision.gameObject.tag == "p2Customer")
        {
            taken = true;
        }
        else
        {
            taken = false;
        }
    }
}

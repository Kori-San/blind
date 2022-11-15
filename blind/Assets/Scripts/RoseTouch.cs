using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rose"))
        {
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseTouch : MonoBehaviour
{
    private LightMechanic light_mechanic;

    void Start()
    {
        light_mechanic = GetComponent<LightMechanic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rose"))
        {
            Destroy(collision.gameObject);
            light_mechanic.light_lock = false;
            light_mechanic.blind_light.pointLightOuterRadius = 50;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMechanic : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D blind_light;
    public GameObject heart;

    public bool light_lock = false; 

    private GameObject game_manager;
    private GameObject princess;
    private Vector3 player;

    private int min_light_radius = 3;
    private float heart_tick;
    private float heart_rate = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.Find("GameManager");
        princess = game_manager.transform.GetChild(0).gameObject;
        blind_light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Light Mechanic
        if (!light_lock)
        {
            if (!game_manager.GetComponent<GameManager>().is_paused)
            {
                blind_light.pointLightOuterRadius -= 5 * 0.025f;
                if (blind_light.pointLightOuterRadius < min_light_radius)
                {
                    blind_light.pointLightOuterRadius = min_light_radius;
                    light_lock = true;
                    heart_tick = Time.time + heart_rate;
                }
            }
        }
        else
        {
            if (Time.time > heart_tick)
            {
                heart_tick += heart_rate;
                Instantiate(heart, transform.position, transform.rotation);
            }
        }
    }
}

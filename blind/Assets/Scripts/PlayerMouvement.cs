using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private UnityEngine.Rendering.Universal.Light2D blind_light;
    private GameObject princess;

    private float start_distance;
    private float curr_distance;

    private int min_light_radius = 3;
    private bool light_lock = false; 

    // Start is called before the first frame update
    private void Start()
    {
        GameObject originalGameObject = GameObject.Find("GameManager");
        princess = originalGameObject.transform.GetChild(0).gameObject;

        blind_light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        rb = GetComponent<Rigidbody2D>(); 
        start_distance = Vector3.Distance(this.transform.position, princess.transform.position);
        Debug.Log(start_distance);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!light_lock)
        {
            curr_distance = Vector3.Distance(this.transform.position, princess.transform.position); 
            blind_light.pointLightOuterRadius -= (start_distance - curr_distance) * 0.025f;
            if (blind_light.pointLightOuterRadius < min_light_radius)
            {
                blind_light.pointLightOuterRadius = min_light_radius;
                light_lock = true;
            }  
        }

        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 14f);
        }
    }
}

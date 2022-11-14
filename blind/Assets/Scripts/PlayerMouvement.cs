using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private UnityEngine.Rendering.Universal.Light2D blind_light;
    private GameObject game_manager;
    private GameObject princess;

    private float start_distance;
    private float curr_distance;

    private int min_light_radius = 3;
    private bool light_lock = false; 
    private int curr_jump = 3; 
    private int max_jump = 3; 

    // Start is called before the first frame update
    private void Start()
    {
        game_manager = GameObject.Find("GameManager");
        princess = game_manager.transform.GetChild(0).gameObject;

        blind_light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        rb = GetComponent<Rigidbody2D>(); 
        start_distance = Vector3.Distance(this.transform.position, princess.transform.position);
        Debug.Log(start_distance);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!light_lock && !game_manager.GetComponent<GameManager>().is_paused)
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

        if (Input.GetButtonDown("Jump") && curr_jump > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 14f);
            curr_jump--;
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        /* Checking if the player is on the ground. */
        if (collision.contacts[0].point.y < transform.position.y)
        {
            curr_jump = max_jump;
        }
    }

}

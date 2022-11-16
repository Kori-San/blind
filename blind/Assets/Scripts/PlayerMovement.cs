using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;

    private bool is_graviting = false;

    private int curr_jump = 3; 
    private int max_jump = 3; 

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    private void Update()
    {
        // Idle
        if(!Input.anyKey && !is_graviting)
        { 
            GetComponent<Animator>().Play("Idle");
        }
        // Movement
        else
        {
            // Get Movement
            float dirX = Input.GetAxis("Horizontal");
            // Change Direction
            transform.localScale = rb.velocity.x < -0.1f ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
            
            // Moving
            if (dirX != 0)
            {
                rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
                if (!is_graviting)
                {
                    GetComponent<Animator>().Play("Run");
                }
            }
            
            // Jumping
            if (Input.GetButtonDown("Jump") && curr_jump > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 14f);
                curr_jump--;
                is_graviting = true;
            }

            // Display right Animation
            if (is_graviting)
            {
                if (rb.velocity.y < -0.1f)
                    GetComponent<Animator>().Play("Fall");
                else
                    GetComponent<Animator>().Play("Jump");
            
            }
        }   
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        /* Checking if the player is on the ground. */
        if (collision.contacts[0].point.y < transform.position.y)
        {
            curr_jump = max_jump;
            is_graviting = false;
        }
    }
}

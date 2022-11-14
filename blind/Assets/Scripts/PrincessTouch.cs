using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincessTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Princess"))
        {
            int next_scene = SceneManager.GetActiveScene().buildIndex + 1;
            int max_scene = SceneManager.sceneCountInBuildSettings - 1;
            if (next_scene <= max_scene)
            {
                SceneManager.LoadScene(next_scene);
            }
            else
            { 
                SceneManager.LoadScene(0);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool is_paused = false;

    private GameObject pause_menu;

    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        pause_menu = this.transform.GetChild(2).gameObject;
        pause_menu.SetActive(false);       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (is_paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }        
    }

    public void Resume()
    {
        Time.timeScale = 1;
        is_paused = false;
        pause_menu.SetActive(false);       
    }

    public void Pause()
    {
        Time.timeScale = 0;
        is_paused = true;
        pause_menu.SetActive(true);       
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool Paused = false;
    public GameObject PauseMenuCanvas;
    public GameObject Computer;


    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    void Stop()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Play()
    {
        if (!Computer.GetComponent<Computer>().ScreenOpen)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;

    }

    public void MainMenuButton()
    {
        PauseMenuCanvas.SetActive(false);
        Paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
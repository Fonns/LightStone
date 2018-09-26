using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject MainMenu;
    public GameObject MenuCamera;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetButtonDown("Pause"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                if (MenuCamera.gameObject.activeSelf)
                {
                }
                else
                {
                    Pause();
                }
            }
        }
	}

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("main");
    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        MainMenu.gameObject.SetActive(false);
        MenuCamera.gameObject.SetActive(false);
    }

    public void Settings()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

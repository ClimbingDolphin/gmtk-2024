using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;

    private bool paused = false;

    public void mainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                menu.SetActive(false);
            }
            else
            {
                menu.SetActive(true);
            }
            paused = !paused;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource clickSource;
    public AudioClip clickClip;

    public void playGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void clickSound()
    {
        clickSource.PlayOneShot(clickClip);
    }

    void Start()
    {
        bgmSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource clickSource;
    public AudioClip clickClip;

    [SerializeField] private SO_GameManagingData gameManagingData;

    public void playGame()
    {
        gameManagingData.levelToLoad = 0;
        SceneManager.LoadSceneAsync("Game");
    }
    public void PlayLevel(int _levelToLoad)
    {
        gameManagingData.levelToLoad = _levelToLoad;
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

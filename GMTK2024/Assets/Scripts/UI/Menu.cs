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
    [SerializeField] private Animator anim;

    public void playGame()
    {
        gameManagingData.levelToLoad = 0;
        StartCoroutine(GameTransition());
    }
    public void PlayLevel(int _levelToLoad)
    {
        gameManagingData.levelToLoad = _levelToLoad;
        StartCoroutine(GameTransition());
    }

    IEnumerator GameTransition()
    {
        anim.SetTrigger("TransitionOut");
        yield return new WaitForSeconds(2f);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] SO_GameManagingData gameManagingData;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource pause;

    public enum PointerLocation
    {
        WORKSHOP,
        BLUEPRINTS,
        SELECTION
    }
    public enum GameState
    {
        GAME_ON,
        GAME_OFF,
        GAME_PAUSED
    }

    public GameState gamestate = GameState.GAME_ON;

    private SO_Level level;
    [SerializeField] private Timer timer;

    private PointerLocation pointerLocation;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 1f;
    }

    private void Start()
    {
        level = gameManagingData.levels[gameManagingData.levelToLoad];
        ItemSelection.Instance.InitializeSelection(level.levelDataItems);
        SheetsManager.Instance.SpawnSheets(level);
        timer.StartTimer((float)GetLevelData().levelDuration);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        switch (gamestate)
        {
            case GameState.GAME_PAUSED:
                gamestate = GameState.GAME_ON;
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                bgm.Play();
                pause.Pause();
                break;
            default:
                gamestate = GameState.GAME_PAUSED;
                Time.timeScale = 0f;
                bgm.Pause();
                pause.Play();
                pauseMenu.SetActive(true);
                break;
        }
    }

    public void StopGame()
    {
        gamestate = GameState.GAME_OFF;
        VerifyResult();
    }

    public void PointerInWorkshop()
    {
        pointerLocation = PointerLocation.WORKSHOP;
    }

    public void PointerInBlueprints()
    {
        pointerLocation = PointerLocation.BLUEPRINTS;
    }
    public void PointerInSelection()
    {
        pointerLocation = PointerLocation.SELECTION;
    }

    public PointerLocation GetPointerLocation()
    {
        return pointerLocation;
    }

    public void VerifyResult()
    {
        ScoreManager.Instance.CheckResult();
    }

    public SO_Level GetLevelData()
    {
        return level;
    }
    public void QuitLevel()
    {
        pauseMenu.SetActive(false);
        StartCoroutine(GameTransition());
    }

    IEnumerator GameTransition()
    {
        Time.timeScale = 1f;
        anim.SetTrigger("TransitionOut");
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadSceneAsync(0);
    }
}

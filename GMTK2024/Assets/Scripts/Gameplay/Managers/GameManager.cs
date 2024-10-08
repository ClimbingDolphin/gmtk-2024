using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] SO_GameManagingData gameManagingData;

    public enum PointerLocation
    {
        WORKSHOP,
        BLUEPRINTS,
        SELECTION
    }
    public enum GameState
    {
        GAME_ON,
        GAME_OFF
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
    }

    private void Start()
    {
        level = gameManagingData.levels[gameManagingData.levelToLoad];
        ItemSelection.Instance.InitializeSelection(level.levelDataItems);
        SheetsManager.Instance.SpawnSheets(level);
        timer.StartTimer((float)GetLevelData().levelDuration);
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
}

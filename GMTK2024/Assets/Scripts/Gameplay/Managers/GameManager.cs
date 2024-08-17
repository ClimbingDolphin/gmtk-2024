using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public enum PointerLocation
    {
        WORKSHOP,
        BLUEPRINTS,
        SELECTION
    }

    [SerializeField] private SO_Level level;

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
        ItemSelection.Instance.InitializeSelection(level.levelDataItems);
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
}

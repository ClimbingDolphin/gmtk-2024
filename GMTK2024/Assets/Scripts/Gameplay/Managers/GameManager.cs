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

    private PointerLocation pointerLocation;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
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

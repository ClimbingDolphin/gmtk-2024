using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private bool inWorkshop = false, inBlueprints = false, inSelection = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void PointerInWorkshop(bool _result)
    {
        inWorkshop = _result;
    }

    public void PointerInBlueprints(bool _result)
    {
        inWorkshop = _result;
    }
    public void PointerInSelection(bool _result)
    {
        inWorkshop = _result;
    }

    public bool InWorkshop()
    {
        return inWorkshop;
    }

    public bool InBlueprints()
    {
        return inWorkshop;
    }
    public bool InSelection()
    {
        return inSelection;
    }
}

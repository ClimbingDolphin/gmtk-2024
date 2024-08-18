using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyItem : MonoBehaviour
{
    protected SO_ToyPart toyPartData;
    protected ToyGameData toyGameData;

    public virtual void InitializeItem(SO_ToyPart _toyPartData, ToyGameData _toyGameData)
    {
        toyPartData = _toyPartData;
        toyGameData = _toyGameData;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyItem : MonoBehaviour
{
    protected SO_ToyPart toyPartData;

    public virtual void InitializeItem(SO_ToyPart _toyPartData)
    {
        toyPartData = _toyPartData;
    }
}

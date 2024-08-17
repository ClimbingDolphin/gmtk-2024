using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level")]
public class SO_Level : ScriptableObject
{
    [System.Serializable]
    public class ItemData
    {
        public SO_ToyPart toyPartData;

    }
    public ItemData[] levelDataItems;
}

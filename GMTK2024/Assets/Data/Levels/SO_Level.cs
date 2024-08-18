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
        public ToyGameData toyGameData;

    }

    public float toyScale = .5f;
    public float minimumScale = .3f;
    public float maximumScale = .7f;
    public ItemData[] levelDataItems;
    public int scaleLevels = 5;
    public int expectedScaleLevel = 1;
}

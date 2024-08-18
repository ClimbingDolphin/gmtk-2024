using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManagingData", menuName = "ScriptableObjects/GameManagingData")]
public class SO_GameManagingData : ScriptableObject
{
    public int levelToLoad;
    public SO_Level[] levels;
}

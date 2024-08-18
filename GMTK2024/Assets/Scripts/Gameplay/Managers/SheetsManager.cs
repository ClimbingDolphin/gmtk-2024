using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetsManager : MonoBehaviour
{
    public static SheetsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SpawnSheets(SO_Level _levelData)
    {
        foreach(SO_Level.SheetData _sheetData in _levelData.sheetDataList)
        {
           SheetPart _sheet = Instantiate(GameManager.Instance.GetLevelData().sheetPart, _sheetData.sheetStartPosition, Quaternion.identity, transform);
            _sheet.SetSprite(_sheetData.sheetSprite);
        }
    }
}

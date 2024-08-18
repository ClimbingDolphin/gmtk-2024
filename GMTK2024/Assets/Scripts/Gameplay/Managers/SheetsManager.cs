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
            _sheet.transform.localScale = GameManager.Instance.GetLevelData().sheetsSize;
            _sheet.SetSprite(_sheetData.sheetSprite);
        }
    }
    public void SetSheetsSortingOrder()
    {
        SheetPart[] _sheetParts = GetComponentsInChildren<SheetPart>();
        for (int i = 0; i < _sheetParts.Length; i++)
        {
            _sheetParts[i].SetSortingOrder();
        }
    }
}

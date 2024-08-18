using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Transform toyPartsParent;

    private int requiredItems = 0;
    private int totalItems = 0;
    private int accurateItems = 0;
    private int placedItems = 0;
    private float totalAccuracy = 0f;
    private int correctlyScaledItems = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SetRequiredAndTotalItems(int _requiredItems, int _totalItems)
    {
        requiredItems = _requiredItems;
        totalItems = _totalItems;
    }

    public void CheckResult()
    {
        accurateItems = 0;

        foreach(Transform _toyHolder in toyPartsParent)
        {
            ToyPart _toyPart = _toyHolder.GetChild(0).GetComponent<ToyPart>();
            if (_toyPart.GetToyGameData().isRequired)
            {
                accurateItems++;
            }
            if (_toyPart.GetCorrectlyScaled())
            {
                correctlyScaledItems++;
            }
            placedItems++;
            totalAccuracy += _toyPart.GetPositionAccuracy();
        }

        float _accurateItemsScore = (float)((float)accurateItems / (float)requiredItems) * 100f;
        float _accuracyPlacement = totalAccuracy / placedItems;
        if(_accuracyPlacement >= 95f)
        {
            _accuracyPlacement = 100f;
        }
        float _accuracyScale = (float)correctlyScaledItems / (float)placedItems * 100f;
        Debug.Log(_accurateItemsScore + " " + _accuracyPlacement + " " + _accuracyScale);
        text.text = Mathf.Round((_accurateItemsScore * _accuracyPlacement * _accuracyScale)/10000f).ToString() + "%";
    }
}

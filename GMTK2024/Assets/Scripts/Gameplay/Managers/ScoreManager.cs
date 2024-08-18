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
            if (_toyHolder.GetChild(0).GetComponent<ToyPart>().GetToyGameData().isRequired)
            {
                accurateItems++;
            }
        }

        text.text = ((float)((float)accurateItems / (float)requiredItems)).ToString();
    }
}

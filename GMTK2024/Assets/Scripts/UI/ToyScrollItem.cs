using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToyScrollItem : ToyItem
{
    [SerializeField] private Image image;
    public override void InitializeItem(SO_ToyPart _toyPartData, ToyGameData _toyGameData)
    {
        base.InitializeItem(_toyPartData, _toyGameData);

        if (toyPartData.sprite != null)
        {
            image.sprite = toyPartData.sprite;
        }
        else
        {
            Debug.Log("missing sprite");
        }

        image.preserveAspect = true;
    }

    public void SpawnToy()
    {
        WorkshopManager.Instance.AddToyPart(toyPartData, this, toyGameData);
        gameObject.SetActive(false);
    }
}

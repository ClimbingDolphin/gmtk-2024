using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToyScrollItem : ToyItem
{
    [SerializeField] private Image image;
    public override void InitializeItem(SO_ToyPart _toyPartData)
    {
        base.InitializeItem(_toyPartData);

        toyPartData = _toyPartData;
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
        WorkshopManager.Instance.AddToyPart(toyPartData, this);
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPart : ToyItem
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private ToyScrollItem toyScrollItem;

    public override void InitializeItem(SO_ToyPart _toyPartData)
    {
        base.InitializeItem(_toyPartData);

        if(_toyPartData.sprite != null)
        {
            spriteRenderer.sprite = _toyPartData.sprite;
        }
        else
        {
            Debug.Log("missing sprite");
        }
    }

    public void SetOriginItem(ToyScrollItem _toyScrollItem)
    {
        toyScrollItem = _toyScrollItem;
    }

    public void GetBackToyPart()
    {
        toyScrollItem.gameObject.SetActive(true);
        Destroy(transform.parent.gameObject);
    }
}

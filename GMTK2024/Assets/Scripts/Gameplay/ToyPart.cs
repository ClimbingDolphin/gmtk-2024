using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPart : ToyItem
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private ToyScrollItem toyScrollItem;
    private bool isRequired = false;

    public override void InitializeItem(SO_ToyPart _toyPartData, ToyGameData _toyGameData)
    {
        base.InitializeItem(_toyPartData, _toyGameData);

        if(_toyPartData.sprite != null)
        {
            spriteRenderer.sprite = _toyPartData.sprite;
        }
        else
        {
            Debug.Log("missing sprite");
        }

        isRequired = _toyGameData.isRequired;
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

    public ToyGameData GetToyGameData()
    {
        return toyGameData;
    }
}

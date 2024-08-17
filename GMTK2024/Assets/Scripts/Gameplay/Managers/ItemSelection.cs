using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelection : MonoBehaviour
{
    public static ItemSelection Instance { get; private set; }

    [SerializeField] private ToyScrollItem scrollItem;

    [SerializeField] private RectTransform content;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void InitializeSelection(SO_Level.ItemData[] _items)
    {
        foreach(SO_Level.ItemData _itemData in _items)
        {
            ToyScrollItem _scrollItem = Instantiate(scrollItem, Vector3.zero, Quaternion.identity, content);
            _scrollItem.InitializeItem(_itemData.toyPartData);
        }
    }
}

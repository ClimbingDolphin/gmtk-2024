using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image itemImage;
    [SerializeField] private ToyScrollItem toyScrollItem;

    private Transform originParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originParent = transform.parent;
        transform.parent = transform.root;
        transform.SetAsLastSibling();
        itemImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Vector3.Scale(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(1f, 1f, 0f));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.parent = originParent;
        switch (GameManager.Instance.GetPointerLocation())
        {
            case GameManager.PointerLocation.WORKSHOP:
                toyScrollItem.SpawnToy();
                break;
            case GameManager.PointerLocation.BLUEPRINTS:
                break;
            case GameManager.PointerLocation.SELECTION:
                break;
        }

        itemImage.raycastTarget = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image itemImage;
    [SerializeField] private ToyScrollItem toyScrollItem;
    [SerializeField] private GameObject backgroundHover;

    private Transform originParent;
    private bool isDragging = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.gamestate == GameManager.GameState.GAME_ON && isDragging == false)
        {
            originParent = transform.parent;
            transform.parent = transform.root;
            transform.SetAsLastSibling();
            itemImage.raycastTarget = false;
            isDragging = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(isDragging)
        transform.position = Vector3.Scale(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(1f, 1f, 0f));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDragging)
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(GameManager.Instance.gamestate == GameManager.GameState.GAME_ON)
        backgroundHover.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        backgroundHover.SetActive(false);
    }
}

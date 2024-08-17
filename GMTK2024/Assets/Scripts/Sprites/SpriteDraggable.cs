using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDraggable : MonoBehaviour
{
    [SerializeField] private ToyPart toyPart;
    [SerializeField] private SpriteRenderer toyVisuals;
    [SerializeField] private string onHoldLayerID;

    private bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    private int startLayerID;
    private void Start()
    {
        startLayerID = toyVisuals.sortingLayerID;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
    private void OnMouseDown()
    {
        if(dragging == false && !Input.GetMouseButtonDown(1))
        {
            dragging = true;
            startPosition = transform.position;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            toyVisuals.sortingLayerID = SortingLayer.NameToID(onHoldLayerID);
        }
    }

    private void OnMouseUp()
    {
        if (dragging)
        {
            dragging = false;
            toyVisuals.sortingLayerID = startLayerID;
            toyVisuals.sortingOrder = WorkshopManager.Instance.GetCurrentPickedItem();
            switch (GameManager.Instance.GetPointerLocation())
            {
                case GameManager.PointerLocation.WORKSHOP:
                    break;
                case GameManager.PointerLocation.BLUEPRINTS:
                    transform.position = startPosition;
                    break;
                case GameManager.PointerLocation.SELECTION:
                    GetBackToyPart();
                    break;
            }
        }
    }

    private void GetBackToyPart()
    {
        toyPart.GetBackToyPart();
    }
}

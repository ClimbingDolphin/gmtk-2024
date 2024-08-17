using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDraggable : MonoBehaviour
{
    [SerializeField] private ToyPart toyPart;

    private bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;

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
        startPosition = transform.position;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        if (dragging)
        {
            dragging = false;
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

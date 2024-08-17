using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDraggable : MonoBehaviour
{
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
        if (GameManager.Instance.GetPointerLocation() != GameManager.PointerLocation.WORKSHOP)
        {
            transform.position = startPosition;
        }
        dragging = false;
    }
}

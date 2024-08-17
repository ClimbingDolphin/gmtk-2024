using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopDrag : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField] private WorkshopZoom workshopZoom;

    [SerializeField] private SpriteRenderer spriteToMove;

    //[SerializeField] private SpriteRenderer mapRenderer;

    [SerializeField] private float dragSpeed = .5f;

    private Vector3 dragOrigin;

    [SerializeField] private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private float MinX, MaxX, MinY, MaxY;

    private bool canMoveCamera = true;

    private void Start()
    {
        MinX = mapMinX - WorkshopManager.Instance.GetGridOffset().x;
        MaxX = mapMaxX - WorkshopManager.Instance.GetGridOffset().x;
        MinY = mapMinY - WorkshopManager.Instance.GetGridOffset().y;
        MaxY = mapMaxY - WorkshopManager.Instance.GetGridOffset().y;
    }

    private void Update()
    {
        PanCamera();

        if (Input.GetMouseButtonUp(1) && canMoveCamera == false)
        {
            canMoveCamera = true;
        }
    }

    private void PanCamera()
    {
        if (canMoveCamera)
        {
            //save position of mouse in world space when drag starts (first time clicked)

            if (Input.GetMouseButtonDown(1))
            {
                dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            }

            //calculate distance between drag and new position if it is held down
            if (Input.GetMouseButton(1))
            {
                Vector3 _difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

                //move the camera by that distance
                Vector3 _oldPos = spriteToMove.transform.position;
                spriteToMove.transform.position = ClampImage(spriteToMove.transform.position + _difference * dragSpeed);
                WorkshopManager.Instance.AddBlueprintOffset(spriteToMove.transform.position - _oldPos);
            }
        }

    }

    private Vector3 ClampImage(Vector3 _targetPosition)
    {

        float _newX = Mathf.Clamp(_targetPosition.x, (MinX * workshopZoom.GetZoomRatio() + WorkshopManager.Instance.GetGridOffset().x), MaxX * workshopZoom.GetZoomRatio() - WorkshopManager.Instance.GetGridOffset().x);
        float _newY = Mathf.Clamp(_targetPosition.y, (MinY * workshopZoom.GetZoomRatio() + WorkshopManager.Instance.GetGridOffset().y), MaxY * workshopZoom.GetZoomRatio() - WorkshopManager.Instance.GetGridOffset().y);
        Debug.Log(new Vector2(MinX * workshopZoom.GetZoomRatio() + WorkshopManager.Instance.GetGridOffset().x, MaxX * workshopZoom.GetZoomRatio() - WorkshopManager.Instance.GetGridOffset().x));

        return new Vector3(_newX, _newY, _targetPosition.z);
    }

    public void ManageCameraMovement(bool _canMove)
    {
        canMoveCamera = _canMove;
    }
}

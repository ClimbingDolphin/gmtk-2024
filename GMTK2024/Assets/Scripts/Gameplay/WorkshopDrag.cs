using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopDrag : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField] private SpriteRenderer spriteToMove;

    [SerializeField] private SpriteRenderer mapRenderer;

    [SerializeField] private float dragSpeed = .5f;

    private Vector3 dragOrigin;

    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private bool canMoveCamera = true;

    private void Awake()
    {
        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
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

        float _newX = Mathf.Clamp(_targetPosition.x, mapMinX, mapMaxX);
        float _newY = Mathf.Clamp(_targetPosition.y, mapMinY, mapMaxY);

        return new Vector3(_newX, _newY, _targetPosition.z);
    }

    public void ManageCameraMovement(bool _canMove)
    {
        canMoveCamera = _canMove;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSheetParts : SheetPart
{
    [SerializeField] private string onHoldLayerID = "HeldItems";

    private bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    private List<Vector2> points = new List<Vector2>();
    private List<Vector2> simplifiedPoints = new List<Vector2>();
    private PolygonCollider2D polygonCollider2D;

    private int startLayerID;
    private void Start()
    {
        startLayerID = spriteRenderer.sortingLayerID;
        transform.parent.SetAsLastSibling();
        WorkshopManager.Instance.SetToysSortingOrder();
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
        if (dragging == false && !Input.GetMouseButtonDown(1) && GameManager.Instance.gamestate == GameManager.GameState.GAME_ON)
        {
            dragging = true;
            startPosition = transform.position;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        spriteRenderer.sortingLayerID = SortingLayer.NameToID(onHoldLayerID);
    }

    private void OnMouseUp()
    {
        if (dragging)
        {
            dragging = false;
            //toyVisuals.sortingOrder = WorkshopManager.Instance.GetCurrentPickedItem();
            switch (GameManager.Instance.GetPointerLocation())
            {
                case GameManager.PointerLocation.WORKSHOP:
                    transform.position = startPosition;
                    break;
                case GameManager.PointerLocation.BLUEPRINTS:
                    break;
                case GameManager.PointerLocation.SELECTION:
                    transform.position = startPosition;
                    break;
            }
            spriteRenderer.sortingLayerID = startLayerID;
            transform.SetAsLastSibling();
            SheetsManager.Instance.SetSheetsSortingOrder();
        }
    }

    public override void SetSprite(Sprite _sprite)
    {
        base.SetSprite(_sprite);
        polygonCollider2D = gameObject.AddComponent<PolygonCollider2D>();
        UpdatePolygonCollider2D();
    }
    public void UpdatePolygonCollider2D(float tolerance = 0.05f)
    {
        polygonCollider2D.pathCount = spriteRenderer.sprite.GetPhysicsShapeCount();
        for (int i = 0; i < polygonCollider2D.pathCount; i++)
        {
            spriteRenderer.sprite.GetPhysicsShape(i, points);
            LineUtility.Simplify(points, tolerance, simplifiedPoints);
            polygonCollider2D.SetPath(i, simplifiedPoints);
        }
    }
}

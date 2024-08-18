using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPart : ToyItem
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float scrollSpeed = 10f;

    private ToyScrollItem toyScrollItem;
    private bool isRequired = false;
    private List<Vector2> points = new List<Vector2>();
    private List<Vector2> simplifiedPoints = new List<Vector2>();
    private PolygonCollider2D polygonCollider2D;
    private int currentScaleLevel = 0;
    private bool hovered = false;

    private void Update()
    {
        float _scroll = Input.GetAxis("Mouse ScrollWheel");
        if (_scroll != 0f && hovered)
        {
            HandleScale(_scroll);
        }
    }

    private void OnMouseEnter()
    {
        hovered = true;
    }

    private void OnMouseExit()
    {
        hovered = false;
    }

    private void HandleScale(float _scroll)
    {
        int _ScaleLevelScroll = Mathf.RoundToInt(currentScaleLevel + _scroll * scrollSpeed);
        currentScaleLevel = Mathf.Clamp(_ScaleLevelScroll, 0, GameManager.Instance.GetLevelData().scaleLevels);
        SetNewScale();

    }
    private float GetScaleFromScaleLevel(int _scaleLevel)
    {
        SO_Level _levelData = GameManager.Instance.GetLevelData();
        return (_levelData.maximumScale - _levelData.minimumScale) / _levelData.scaleLevels * _scaleLevel + _levelData.minimumScale;
    }

    private void SetNewScale()
    {
        float _newScale = GetScaleFromScaleLevel(currentScaleLevel);
        transform.localScale = new Vector3(_newScale, _newScale, 1f);
    }

    public override void InitializeItem(SO_ToyPart _toyPartData, ToyGameData _toyGameData)
    {
        base.InitializeItem(_toyPartData, _toyGameData);

        if(_toyPartData.sprite != null)
        {
            spriteRenderer.sprite = _toyPartData.sprite;
            polygonCollider2D = gameObject.AddComponent<PolygonCollider2D>();
            UpdatePolygonCollider2D();

        }
        else
        {
            Debug.Log("missing sprite");
        }

        isRequired = _toyGameData.isRequired;
        currentScaleLevel = _toyGameData.startScaleLevel;
        SetNewScale();
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

    public void UpdatePolygonCollider2D(float tolerance = 0.05f)
    {
        polygonCollider2D.pathCount = spriteRenderer.sprite.GetPhysicsShapeCount();
        for (int i = 0; i < polygonCollider2D.pathCount; i++)
        {
            spriteRenderer.sprite.GetPhysicsShape(i, points);
            LineUtility.Simplify(points, tolerance, simplifiedPoints);
            polygonCollider2D.SetPath(i, simplifiedPoints);
        }
        //polygonCollider2D.pathCount = 1;
        if (toyPartData.removeCollisions)
        {
            polygonCollider2D.pathCount = toyPartData.collisionSize;
        }
        if(polygonCollider2D.pathCount == 0 || toyPartData.overrideCollision)
        {
            Destroy(polygonCollider2D);
            CircleCollider2D _circleCollision = gameObject.AddComponent<CircleCollider2D>();
            _circleCollision.radius = toyPartData.radiusCollision;
        }
    }

    public float GetPositionAccuracy()
    {
        return Mathf.Round(Mathf.Clamp(2 - Vector2.Distance(transform.localPosition, toyGameData.expectedPosition), 0f, 2f) / 2f * 100f);
    }

    public bool GetCorrectlyScaled()
    {
        return currentScaleLevel == GameManager.Instance.GetLevelData().expectedScaleLevel;
    }

}

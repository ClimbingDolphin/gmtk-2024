using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopManager : MonoBehaviour
{
    public static WorkshopManager Instance { get; private set; }

    [SerializeField] private GameObject toyPart;
    [SerializeField] private Transform toyPartsParent;
    [SerializeField] private Transform blueprintsBackground;

    [SerializeField] private Material blueprintMaterial;

    [SerializeField] private float minimumTransformScale = .5f;
    [SerializeField] private Transform transformToScale;
    private Vector2 blueprintOffset;
    private Vector3 currentToyPartScale;
    private int currentPickedItem = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        blueprintMaterial = blueprintsBackground.GetComponent<SpriteRenderer>().material;
        blueprintOffset = blueprintMaterial.GetVector("_GridOffset");
        blueprintsBackground.position = -blueprintOffset;
    }

    public void AddToyPart(SO_ToyPart _toyPartData, ToyScrollItem _toyScrollItem)
    {
        ToyPart _toyPart = Instantiate(toyPart, blueprintOffset * -1f, Quaternion.identity, toyPartsParent).transform.GetChild(0).GetComponent<ToyPart>();
        _toyPart.transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector3)blueprintOffset + new Vector3(0, 0, 10f);
        _toyPart.transform.localScale = currentToyPartScale;
        _toyPart.InitializeItem(_toyPartData);
        _toyPart.SetOriginItem(_toyScrollItem);
    }

    public void SetScale(float _newScale)
    {
        currentToyPartScale = new Vector3(_newScale + minimumTransformScale, _newScale + minimumTransformScale, 1f);

        foreach (Transform _transform in toyPartsParent)
        {
            _transform.localScale = currentToyPartScale;
        }
    }

    public void AddBlueprintOffset(Vector3 _offset)
    {
        blueprintMaterial.SetVector("_AdditionalOffset", (Vector4)(-blueprintsBackground.position - (Vector3)blueprintOffset));
        //blueprintMaterial.SetVector("_AdditionOffset", blueprintMaterial.GetVector("_AdditionOffset") + new Vector4(_offset.x *2, _offset.y*2, 0f, 0f));
    }

    public int GetCurrentPickedItem()
    {
        currentPickedItem++;
        return currentPickedItem;
    }
}

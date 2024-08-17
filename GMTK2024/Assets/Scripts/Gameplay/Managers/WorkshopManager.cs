using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopManager : MonoBehaviour
{
    public static WorkshopManager Instance { get; private set; }

    [SerializeField] private GameObject toyPart;
    [SerializeField] private Transform toyPartsParent;

    [SerializeField] private Material blueprintMaterial;
    [SerializeField] private float minimumTransformScale = .5f;
    [SerializeField] private Transform transformToScale;
    private Vector2 blueprintOffset;
    private Vector3 currentToyPartScale;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        blueprintOffset = blueprintMaterial.GetVector("_GridOffset");
    }

    public void AddToyPart(SO_ToyPart _toyPartData, ToyScrollItem _toyScrollItem)
    {
        ToyPart _toyPart = Instantiate(toyPart, blueprintOffset, Quaternion.identity, toyPartsParent).transform.GetChild(0).GetComponent<ToyPart>();
        _toyPart.transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10f);
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

    
}

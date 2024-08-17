using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopZoom : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 10f;
    [SerializeField] private float defaultZoom = 1f;
    [SerializeField] private float scrollMin, scrollMax;
    [SerializeField] private SpriteRenderer blueprintBackground;
    private Material blueprintMaterial;

    // Start is called before the first frame update
    void Start()
    {
        blueprintMaterial = blueprintBackground.material;
        blueprintMaterial.SetFloat("_CellSize", defaultZoom);
        HandleZoom(0f);
    }

    // Update is called once per frame
    void Update()
    {
        float _scroll = Input.GetAxis("Mouse ScrollWheel");
        if(_scroll != 0f)
        {
            HandleZoom(_scroll);
        }
    }

    private void HandleZoom(float _scroll)
    {
        float _newScale = Mathf.Clamp((blueprintMaterial.GetFloat("_CellSize") + _scroll * scrollSpeed), scrollMin, scrollMax);
        blueprintMaterial.SetFloat("_CellSize", _newScale);
        WorkshopManager.Instance.SetScale(GetZoomRatio());
    }

    public float GetZoomRatio()
    {
        return (blueprintMaterial.GetFloat("_CellSize") - scrollMin) / (scrollMax - scrollMin);
    }
}

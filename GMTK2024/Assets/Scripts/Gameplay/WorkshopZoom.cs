using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopZoom : MonoBehaviour
{
    [SerializeField] private float defaultZoom = 1f;
    [SerializeField] private float scrollMin, scrollMax;
    [SerializeField] private SpriteRenderer blueprintBackground;
    [SerializeField] private WorkshopDrag workshopDrag;
    private Material blueprintMaterial;

    // Start is called before the first frame update
    void Start()
    {
        blueprintMaterial = blueprintBackground.material;
        blueprintMaterial.SetFloat("_CellSize", defaultZoom);
        //HandleZoom(0f);
    }

    // Update is called once per frame
    void Update()
    {
    }


    public float GetZoomRatio()
    {
        return (blueprintMaterial.GetFloat("_CellSize") - scrollMin) / (scrollMax - scrollMin);
    }
}

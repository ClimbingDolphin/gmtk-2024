using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SO_ToyPart))]
public class ToyPartEditor : Editor
{
    private SO_ToyPart toyPartData;

    private void OnEnable()
    {
        toyPartData = target as SO_ToyPart;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (toyPartData.sprite == null)
            return;

        //Get the sprite
        Texture2D _sprite = AssetPreview.GetAssetPreview(toyPartData.sprite);

        //Define image size
        GUILayout.Label("", GUILayout.Height(120), GUILayout.Width(120));

        //Draw the image
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), _sprite);
    }
}

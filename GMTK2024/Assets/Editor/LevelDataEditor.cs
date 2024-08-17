using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SO_Level))]
public class LevelDataEditor : Editor
{
    private SO_Level levelItem;

    private void OnEnable()
    {
        levelItem = target as SO_Level;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        foreach(SO_Level.ItemData _data in levelItem.levelDataItems)
        {
            if (_data.toyPartData.sprite == null)
                return;

            //Get the sprite
            Texture2D _sprite = AssetPreview.GetAssetPreview(_data.toyPartData.sprite);

            //Define image size
            GUILayout.Label("", GUILayout.Height(50), GUILayout.Width(50));

            //Draw the image
            GUI.DrawTexture(GUILayoutUtility.GetLastRect(), _sprite);
        }
    }
}

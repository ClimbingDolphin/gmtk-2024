using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ToyPart", menuName = "ScriptableObjects/Toy Part")]
public class SO_ToyPart : ScriptableObject
{
    public Sprite sprite;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    [Header("Item Data")]
    public string id;

    public bool overrideCollision = false;
    public float radiusCollision = 5f;
    public bool removeCollisions = false;
    public int collisionSize = 1;

}

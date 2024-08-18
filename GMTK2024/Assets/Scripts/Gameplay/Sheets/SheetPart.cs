using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetPart : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;


    public virtual void SetSprite(Sprite _sprite)
    {
        spriteRenderer.sprite = _sprite;
    }
}

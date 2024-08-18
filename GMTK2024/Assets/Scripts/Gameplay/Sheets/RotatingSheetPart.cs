using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSheetPart : SheetPart
{
    [SerializeField] private float rotationSpeed = 20f;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gamestate == GameManager.GameState.GAME_ON)
        {
            transform.eulerAngles += new Vector3(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }
}

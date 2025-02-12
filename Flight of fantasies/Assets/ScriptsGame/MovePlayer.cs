using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SpawnGamepad1 : MonoBehaviour
{
    private Vector2 _temp;
    Vector2 pos;


    private void Update()
    {
        Click();
    }

    private void Click()
    {
        if (Input.GetMouseButtonDown(0))
            _temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             pos.y = transform.position.y - (_temp.y - touchPos1.y);
             pos.x = transform.position.x - (_temp.x - touchPos1.x);
            transform.position = pos;
            _temp = touchPos1;
        }
      
    }
}

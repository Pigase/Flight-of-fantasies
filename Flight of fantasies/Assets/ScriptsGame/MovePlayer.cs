using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SpawnGamepad1 : MonoBehaviour
{
    [SerializeField] private GameObject _rightObgect;
    [SerializeField] private GameObject _upObgect;
    [SerializeField] private float _Y;
    [SerializeField] private float _X;

    private Vector2 _tempMove;
    private Vector2 pos;
    private bool playerLive = true;

    private void Start()
    {
        _Y = _upObgect.transform.position.y;
        _X = _rightObgect.transform.position.x;
    }
    private void Update()
    {
        if (Time.deltaTime <= 0f)
            return;
        if (playerLive)
        {
            Click();
            Barier();
        }
    }

    private void Barier()
    {
        if (transform.position.x > _X)
            transform.position = new Vector2 (_X,transform.position.y);
        if (transform.position.x < -_X)
            transform.position = new Vector2(-_X, transform.position.y);
        if (transform.position.y > _Y)
            transform.position = new Vector2(transform.position.x, _Y);
        if (transform.position.y < -_Y)
            transform.position = new Vector2(transform.position.x, -_Y);

    }
    private void Click()
    {
        if (Input.GetMouseButtonDown(0))
            _tempMove = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             pos.y = transform.position.y - (_tempMove.y - touchPos1.y);
             pos.x = transform.position.x - (_tempMove.x - touchPos1.x);
            transform.position = pos;
            _tempMove = touchPos1;
        }
      
    }
    private void PlayerDied()
    {
        playerLive = false;
    }
    private void OnEnable()
    {
        HealthPlayer.Died += PlayerDied;
    }

    private void OnDisable()
    {
        HealthPlayer.Died -= PlayerDied;
    }
}

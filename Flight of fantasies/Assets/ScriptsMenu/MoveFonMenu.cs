using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveFonMenu : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject[] _sprite;


    private float minPosY;
    private float maxPosY;

    private void Start()
    {
        CheckPos();
    }
    
    private void FixedUpdate()
    {
        MoveFon();
    }

    private void MoveFon()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

       if(transform.position.y <= minPosY)
       {
            transform.position = new Vector2(transform.position.x, maxPosY);
       }
    }
    private void CheckPos()
    {
        minPosY = transform.position.y;
        maxPosY = transform.position.y;

        for (int i = 0; i < _sprite.Length; i++)
        {
            if (_sprite[i].transform.position.y > maxPosY) 
            { 
                maxPosY = _sprite[i].transform.position.y; 
            } 
            else 
            {
                minPosY = _sprite[i].transform.position.y;
            }
        }

        minPosY -= maxPosY;
    }
}

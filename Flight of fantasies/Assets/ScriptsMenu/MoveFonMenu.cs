using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveFonMenu : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _restartPosY;
    [SerializeField]private float _minSizeSpriteY;

    private void Update()
    {
        MoveFon();
    }

    private void MoveFon()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < _minSizeSpriteY)
            transform.position = new Vector2(0,_restartPosY);
    }
}

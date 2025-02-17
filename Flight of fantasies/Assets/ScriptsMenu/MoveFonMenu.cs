using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveFonMenu : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _restartPosY;
    [SerializeField] private SpriteRenderer _sprite;

    private float _minSizeSpriteY;

    private Vector2 zeroVector = new Vector2(0,0);
    private Vector2 spriteSize;

    private void Start()
    {
        transform.parent.position = zeroVector;
        spriteSize = _sprite.bounds.size;
        _minSizeSpriteY = spriteSize.y;
        Debug.Log(_minSizeSpriteY);
    }
    
    private void FixedUpdate()
    {
        MoveFon();
    }

    private void MoveFon()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y <= 0 )
        {
            if (Vector2.Distance(zeroVector, transform.position) >= _minSizeSpriteY)
            {
                transform.position = new Vector2(transform.position.x, _restartPosY);
                Debug.Log(_restartPosY);
            }
        }
    }
}

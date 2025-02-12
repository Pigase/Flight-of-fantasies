using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float _speed = 3f; 
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(0 * _speed * Time.deltaTime, -1 * _speed * Time.deltaTime, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Meteor : MonoBehaviour
{
    private float _randomSpeed;
    private float _randomX;
    private Vector3 _target;
    private void Update()
    {
        Move();
    }

    private void OnEnable()
    {
        _randomSpeed = Random.Range(0.5f, 2);
        _randomX = Random.Range(-2f, 2f);
        _target = new Vector3(_randomX, -5.7f,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MeteorDestroyer")
        gameObject.SetActive(false);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _randomSpeed * Time.deltaTime);
    }
}

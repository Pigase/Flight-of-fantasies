using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;

    private void Update()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletDestroyer")
            gameObject.SetActive(false);
    }

    private void Move()
    {
        transform.Translate(0, 1f * _speed * Time.deltaTime, 0);
    }
}

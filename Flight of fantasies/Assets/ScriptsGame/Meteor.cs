using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float _maxHealth ;
    [SerializeField] private TextMeshProUGUI _texthHealth ;

    private float _randomSpeed;
    private float _randomX;
    private float _randomScale;
    private float _randomRotateSpeed;
    private Vector3 _target;
    private float _currentHealth;

    private void Update()
    {
        Move();
        RotateMeteor();
    }

    private void OnEnable()
    {
        _randomSpeed = Random.Range(0.5f, 2);
        _randomX = Random.Range(-2f, 2f);
        _randomScale = Random.Range(0.25f, 0.6f);
        _randomRotateSpeed = Random.Range(10f, 80f);
        _target = new Vector3(_randomX, -6.16f,0);
        _currentHealth = _maxHealth;
        _texthHealth.text = _currentHealth.ToString();
        transform.localScale = new Vector3(_randomScale, _randomScale, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MeteorDestroyer")
        gameObject.SetActive(false);
        if (collision.tag == "Bullet")
        {
            _currentHealth -= 2;
            _texthHealth.text = _currentHealth.ToString();

            if (_currentHealth <= 0 )
                gameObject.SetActive(false);

            collision.gameObject.SetActive(false);
        }
    }
    private void RotateMeteor()
    {
        transform.Rotate(0,0, -_randomRotateSpeed * Time.deltaTime);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _randomSpeed * Time.deltaTime);
    }
}

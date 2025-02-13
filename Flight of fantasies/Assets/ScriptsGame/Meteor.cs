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
    private Vector3 _target;
    private float _currentHealth;

    private void Update()
    {
        Move();
    }

    private void OnEnable()
    {
        _randomSpeed = Random.Range(0.5f, 2);
        _randomX = Random.Range(-2f, 2f);
        _target = new Vector3(_randomX, -5.7f,0);
        _currentHealth = _maxHealth;
        _texthHealth.text = _currentHealth.ToString();
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

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _randomSpeed * Time.deltaTime);
    }
}

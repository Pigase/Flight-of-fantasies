using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float _firstHealth=10;
    [SerializeField] private float _coefficientHealth;
    [SerializeField] private TextMeshProUGUI _texthHealth ;
    [SerializeField] private GameManipulator _gameManipulator;

    private float _maxHealth;
    private float _randomSpeed;
    private float _randomX;
    private float _randomScale;
    private float _randomRotateSpeed;
    private Vector3 _target;
    private float _currentHealth;

    public static Action<float> Damage;
    public static Action DestroyMeteor;
    public static Action Points;
    public static Action<float> Crystals;


    private void Update()
    {
        Move();
        RotateMeteor();
    }

    private void OnEnable()
    {
        DestroyMeteor?.Invoke();
        _randomSpeed = UnityEngine.Random.Range(0.5f, 2);
        _randomX = UnityEngine.Random.Range(-2f, 2f);
        _randomScale = UnityEngine.Random.Range(0.25f, 0.6f);
        _randomRotateSpeed = UnityEngine.Random.Range(10f, 80f);
        
        _target = new Vector3(_randomX, -6.16f,0);
        _maxHealth = Mathf.Round(_firstHealth * Mathf.Pow((1 + _coefficientHealth), _gameManipulator._NumberOfMeteors));//формула увелич хп
        _currentHealth = _maxHealth;
        _texthHealth.text = _currentHealth.ToString();
        transform.localScale = new Vector3(_randomScale, _randomScale, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*событие DestroyMeteor сообщает манипулятору об разрушении метеорита об разрушитель или когда 0 хп 
         чтобы увелить кол-во пройденных метеоров и тем самым увеличить их хп.Еще одно событие Points
        сообщает именно о разрушеннии метеора игроком чтобы прибавить очки,и еще одно событие передающие кол-во
        кристалов(макс хп))*/
        if (collision.tag == "MeteorDestroyer")
        {
            DestroyMeteor?.Invoke();
            gameObject.SetActive(false);
        }

        if (collision.tag == "Bullet")
        {
            _currentHealth -= 2;
            _texthHealth.text = _currentHealth.ToString();

            if (_currentHealth <= 0)
            {
                Points?.Invoke();
                Crystals?.Invoke(_maxHealth);
                DestroyMeteor?.Invoke();
                gameObject.SetActive(false);
            }

            collision.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Damage?.Invoke(_currentHealth);
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

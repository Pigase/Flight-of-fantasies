using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float _firstHealth = 5;
    [SerializeField] private float _coefficientHealth;
    [SerializeField] private TextMeshProUGUI _texthHealth ;
    [SerializeField] private GameManipulator _gameManipulator;
    [SerializeField] private HealthPlayer _healthPlayer;
    [SerializeField] private AudioSource _dieSound;
    [SerializeField] private GameObject _right;

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
        float barrier = _right.transform.position.x;
        _randomX = UnityEngine.Random.Range(-barrier, barrier);
        _randomScale = UnityEngine.Random.Range(1.5f, 2.5f);
        _randomRotateSpeed = UnityEngine.Random.Range(10f, 80f);
        
        _target = new Vector3(_randomX, -6.16f,0);
        _maxHealth = GetHp();//формула увелич хп
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
            _currentHealth -= PlayerPrefs.GetFloat("LevelDamage", 1);
            _texthHealth.text = _currentHealth.ToString();

            if (_currentHealth <= 0)
            {
                _dieSound.Play();
                //gameObject?.GetComponent<AudioSource>().Play();
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
        if (collision.tag == "Player" && _healthPlayer.IsInvulnerability == false)
        {
            DestroyMeteor?.Invoke();
            Points?.Invoke();
            gameObject.SetActive(false);
            Damage?.Invoke(_currentHealth);
        }
    }
    private float GetHp()
    {
        float minRan = Mathf.Round(_gameManipulator._NumberOfMeteors*0.6f);
        float maxRan = Mathf.Round(_gameManipulator._NumberOfMeteors * 1.4f);
        float randomSpread = Mathf.Round(UnityEngine.Random.Range(minRan, maxRan));
        float HP = _firstHealth + randomSpread;
        return HP;
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

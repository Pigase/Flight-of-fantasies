using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneretionBullets : MonoBehaviour
{
    [SerializeField] private int _poolCount = 12;
    [SerializeField] private float _dalayTime;
    [SerializeField] private bool _autoExpande = true;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private AudioSource _shootSound;

    private bool playerLive = true;

    private PoolMono<Bullet> _pool;

    private void Start()//создыем пул камней
    {
        _pool = new PoolMono<Bullet>(_prefab, _poolCount, transform);
        _pool.autoExpand = _autoExpande;

        _dalayTime = 0.41f-(0.01f*PlayerPrefs.GetFloat("LevelSpeed", 1));
        CreateBullet();
    }
    private void CreateBullet()//вызываем метод взятие камней из пула который потом вызывает сам себя
    {
        var meteor = _pool.GetFreeElement();
        meteor.transform.position = transform.position;
        meteor.transform.parent = null;
        meteor.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        _shootSound.Play();
        if (playerLive)
        {
            Invoke("CreateBullet", _dalayTime);
        }
    }
    private void OnEnable()
    {
        HealthPlayer.Died += PlaerDied;
    }
    private void OnDisable()
    {
        HealthPlayer.Died -= PlaerDied;
    }

    private void PlaerDied()
    {
        playerLive = false;
    }
}

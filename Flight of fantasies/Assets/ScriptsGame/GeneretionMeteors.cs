using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneretionEnemies : MonoBehaviour
{
    [SerializeField] private int _poolCount = 12;
    [SerializeField] private bool _autoExpande = true;
    [SerializeField] private Meteor _prefab;
    [SerializeField] private GameObject _right;

    private float _barrier;

    private PoolMono<Meteor> _pool;
    private void Start()//создыем пул камней
    {
        _pool = new PoolMono<Meteor>(_prefab, _poolCount, transform);
        _pool.autoExpand = _autoExpande;

        _barrier = _right.transform.position.x;

        CreateMeteor();
    }
    private void CreateMeteor()//вызываем метод взятие камней из пула который потом вызывает сам себя
    {
        float randomRange = Random.Range(-_barrier, _barrier);
        float randomTimeSpawn = Random.Range(0.1f, 2f);
        var meteor = _pool.GetFreeElement();
        meteor.transform.position = transform.position;
        meteor.transform.parent = null;
        meteor.transform.position = new Vector3(transform.position.x + randomRange, transform.position.y, 0);
        Invoke("CreateMeteor", randomTimeSpawn);
    }

}

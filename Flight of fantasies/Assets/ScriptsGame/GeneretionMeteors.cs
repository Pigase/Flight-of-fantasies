using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneretionEnemies : MonoBehaviour
{
    [SerializeField] private int _poolCount = 12;
    [SerializeField] private bool _autoExpande = true;
    [SerializeField] private Meteor _prefab;

    private PoolMono<Meteor> _pool;
    private void Start()
    {
        _pool = new PoolMono<Meteor>(_prefab, _poolCount, transform);
        _pool.autoExpand = _autoExpande;

        CreateMeteor();
    }
    private void CreateMeteor()
    {
        float randomRange = Random.Range(-2f, 2f);
        float randomTimeSpawn = Random.Range(0.1f, 2f);
        var meteor = _pool.GetFreeElement();
        meteor.transform.position = transform.position;
        meteor.transform.parent = null;
        meteor.transform.position = new Vector3(transform.position.x + randomRange, transform.position.y, 0);
        Invoke("CreateMeteor", randomTimeSpawn);
    }

}

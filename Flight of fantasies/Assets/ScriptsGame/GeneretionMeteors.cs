using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneretionEnemies : MonoBehaviour
{
    [SerializeField] private int _poolCount = 12;
    [SerializeField] private bool _autoExpande = true;
    [SerializeField] private float _delayTime = 0.1f;
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
        var meteor = _pool.GetFreeElement();
        meteor.transform.position = transform.position;
        meteor.transform.parent = null;
        meteor.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        Invoke("CreateMeteor", _delayTime);
    }

}

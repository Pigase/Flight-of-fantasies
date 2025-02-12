using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneretionBullets : MonoBehaviour
{
    [SerializeField] private int _poolCount = 12;
    [SerializeField] private float _dalayTime = 0.1f;
    [SerializeField] private bool _autoExpande = true;
    [SerializeField] private Bullet _prefab;

    private PoolMono<Bullet> _pool;
    private void Start()//������� ��� ������
    {
        _pool = new PoolMono<Bullet>(_prefab, _poolCount, transform);
        _pool.autoExpand = _autoExpande;

        CreateBullet();
    }
    private void CreateBullet()//�������� ����� ������ ������ �� ���� ������� ����� �������� ��� ����
    {
        var meteor = _pool.GetFreeElement();
        meteor.transform.position = transform.position;
        meteor.transform.parent = null;
        meteor.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        Invoke("CreateBullet", _dalayTime);
    }

}

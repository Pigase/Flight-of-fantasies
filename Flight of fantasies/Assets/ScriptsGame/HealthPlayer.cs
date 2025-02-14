using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private float _maxHealthPlayer;
    [SerializeField] private float _currentHealthPlayer;
    [SerializeField] private float _timeInvulnerability;
    [SerializeField] private TextMeshProUGUI _textHealthPlayer;
    [SerializeField] private EdgeCollider2D _colliderPlayer;
 
    private bool _isInvulnerability;

    public static Action Died;
    private void Start()
    {
        _currentHealthPlayer = _maxHealthPlayer;
        _textHealthPlayer.text = _currentHealthPlayer.ToString();
    }
    private void OnEnable()
    {
        Meteor.Damage += GetDamage;
    }
    private void OnDisable()
    {
        Meteor.Damage -= GetDamage;
    }
    private void GetDamage(float damage)
    {
        if (_isInvulnerability == false)
        {
            if (_currentHealthPlayer > damage)
            {
                _currentHealthPlayer -= damage;
                _textHealthPlayer.text = _currentHealthPlayer.ToString();
                StartCoroutine(DoInvulnerability());
            }
            else
            {
                _currentHealthPlayer = 0;
                _textHealthPlayer.text = _currentHealthPlayer.ToString();
                _colliderPlayer.enabled = false;
                Died?.Invoke();
            }
        }
    }
    IEnumerator DoInvulnerability()
    {
        _isInvulnerability= true;
        yield return new WaitForSeconds(_timeInvulnerability);
        _isInvulnerability = false;
    }
}

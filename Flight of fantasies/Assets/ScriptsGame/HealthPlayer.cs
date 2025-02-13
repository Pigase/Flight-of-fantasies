using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private float _maxHealthPlayer;
    [SerializeField] private float _currentHealthPlayer;
    [SerializeField] private float _timeInvulnerability;

    private bool _isInvulnerability;

    private void Start()
    {
        _currentHealthPlayer = _maxHealthPlayer;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("fafaff");
        if (collision.tag == "Meteor")
        {
            Debug.Log("meteor");
            Damage();
        }
    }
    private void Damage()
    {
        if (_isInvulnerability == false)
        {
            _currentHealthPlayer -= 10;
            StartCoroutine(DoInvulnerability());
        }
    }
    IEnumerator DoInvulnerability()
    {
        _isInvulnerability= true;
        yield return new WaitForSeconds(_timeInvulnerability);
        _isInvulnerability = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManipulator : MonoBehaviour
{
    [SerializeField] private GameObject _diedCanvas;

    [SerializeField] private float _numberOfMeteor = 1;
    [SerializeField] private float _points = 0;
    public float _NumberOfMeteors => _numberOfMeteor;
    public float _Points => _points;

    public static Action GetCrystals;

    private void OnEnable()
    {
        HealthPlayer.Died += DiedScreen;
        Meteor.DestroyMeteor += UpNumberOfMeteor;
        Meteor.Points += UpPoints;

    }

    private void OnDisable()
    {
        HealthPlayer.Died -= DiedScreen;
        Meteor.DestroyMeteor -= UpNumberOfMeteor;
        Meteor.Points -= UpPoints;
    }

    private void UpPoints()
    {
        _points++;
    }
    private void UpNumberOfMeteor()
    {
        _numberOfMeteor++;
    }
    private void DiedScreen()
    {
        GetCrystals?.Invoke();

        if (_points > PlayerPrefs.GetFloat("RecordPoints", 0))
        {
            PlayerPrefs.SetFloat("RecordPoints", _points);
        }

        Time.timeScale = 0f;
        _diedCanvas.SetActive(true);
    }

    public void Home()
    {
        GetCrystals?.Invoke();

        if (_points > PlayerPrefs.GetFloat("RecordPoints", 0))
        {
            PlayerPrefs.SetFloat("RecordPoints", _points);
        }

        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManipulator : MonoBehaviour
{
    [SerializeField] private GameObject _diedCanvas;
    private void OnEnable()
    {
        HealthPlayer.Died += DiedScreen;

    }

    private void OnDisable()
    {
        HealthPlayer.Died -= DiedScreen;
    }

    private void DiedScreen()
    {
        Time.timeScale = 0f;
        _diedCanvas.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

}

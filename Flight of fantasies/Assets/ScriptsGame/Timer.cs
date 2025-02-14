using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTimer;

    [SerializeField] private float seconds = 0;
    [SerializeField] private float minute = 0;

    public float secondsTimer => seconds;
    public float minuteTimer => minute;


    private void Update()
    {
        Secundomer();
    }

    private void Secundomer()
    {
        seconds += Time.deltaTime;

        if (seconds >= 59)
        {
            minute++;
            seconds = 0;
        }

        _textTimer.text = minute.ToString("") + ":" + Mathf.Round(seconds).ToString("");
    }

}

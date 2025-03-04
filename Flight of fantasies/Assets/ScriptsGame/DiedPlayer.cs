using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _diedCanvas;

    public void StopTime()
    {
        Time.timeScale = 0f;
    }
    public void DiedScreen()
    {
        _diedCanvas.SetActive(true);
    }
}

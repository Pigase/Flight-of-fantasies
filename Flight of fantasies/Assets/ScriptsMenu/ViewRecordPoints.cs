using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewRecordPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textRecordPointsMenu;

    private void Update()
    {
        _VeiwRecordPointsMenu();
    }
    private void _VeiwRecordPointsMenu()
    {
        _textRecordPointsMenu.text = PlayerPrefs.GetFloat("RecordPoints", 0).ToString();
    }
}

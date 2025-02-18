using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VeiwCristals : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCrystalsMenu;

    private void Update()
    {
        _VeiwCrystalsInMenu();
    }
    private void _VeiwCrystalsInMenu()
    {
        _textCrystalsMenu.text = PlayerPrefs.GetFloat("Crystals",0).ToString();
    }
}

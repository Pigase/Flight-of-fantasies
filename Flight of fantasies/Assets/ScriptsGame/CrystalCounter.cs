using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrystalCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCrystalInGame;
    [SerializeField] private float _crystals = 0;

    private void Update()
    {
        ViewCrystals();
    }
    private void OnEnable()
    {
        Meteor.Crystals += PlusCrystals;
        GameManipulator.GetCrystals += SaveCrystals;
    }

    private void OnDisable()
    {
        Meteor.Crystals -= PlusCrystals;
        GameManipulator.GetCrystals -= SaveCrystals;

    }
    private void SaveCrystals()
    {
        PlayerPrefs.SetFloat("Crystals",PlayerPrefs.GetFloat("Crystals",0)+_crystals);
    }
    private void PlusCrystals(float cristalsThisMeteor)
    {
        
        _crystals += cristalsThisMeteor;
    }
    private void ViewCrystals()
    {
        _textCrystalInGame.text = _crystals.ToString();

    }
}

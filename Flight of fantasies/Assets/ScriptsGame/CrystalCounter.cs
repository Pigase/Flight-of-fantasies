using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrystalCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCrystalInGame;
    [SerializeField] private CrystalCounter _crystalCounter;
    [SerializeField] private float _crystals = 0;
    public float _Crystals => _crystals;

    private void Update()
    {
        ViewCrystals();
    }
    private void OnEnable()
    {
        Meteor.Crystals += PlusCrystals;
    }

    private void OnDisable()
    {
        Meteor.Crystals -= PlusCrystals;
    }
    private void PlusCrystals(float cristalsThisMeteor)
    {
        _crystals += cristalsThisMeteor;
    }
    private void ViewCrystals()
    {
        _textCrystalInGame.text = _crystalCounter._Crystals.ToString();

    }
}

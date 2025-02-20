using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpParametars : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textLevelHealth;
    [SerializeField] private TextMeshProUGUI _textLevelSpeed;
    [SerializeField] private TextMeshProUGUI _textLevelDamage;

    [SerializeField] private TextMeshProUGUI _textPriseHealth;
    [SerializeField] private TextMeshProUGUI _textPriseSpeed;
    [SerializeField] private TextMeshProUGUI _textPriseDamage;

    [SerializeField] private TextMeshProUGUI _textUpHealth;
    [SerializeField] private TextMeshProUGUI _textUpSpeed;
    [SerializeField] private TextMeshProUGUI _textUpDamage;

    private float _temp;

    private void Update()
    {
        ViewLevelText();
        ViewUpParameters();
        ViewPrise();
    }
    private void ViewLevelText()
    {
        _textLevelHealth.text = PlayerPrefs.GetFloat("LevelHealth", 1)+" LVL";
        _textLevelSpeed.text = PlayerPrefs.GetFloat("LevelSpeed", 1) + " LVL";
        _textLevelDamage.text = PlayerPrefs.GetFloat("LevelDamage", 1) + " LVL";
    }
    private void ViewUpParameters()
    {
        _textUpHealth.text = (PlayerPrefs.GetFloat("LevelHealth", 1)*50) + "<color=green>+30</color>";
        _textUpSpeed.text = 95+(PlayerPrefs.GetFloat("LevelSpeed", 1)*5) + "%<color=green>+5%</color>";
        _textUpDamage.text = PlayerPrefs.GetFloat("LevelDamage", 1) + "<color=green>+1</color>";
    }
    private void ViewPrise()
    {
        _textPriseHealth.text = (PlayerPrefs.GetFloat("LevelHealth", 1) * 50).ToString();
        _textPriseSpeed.text = (PlayerPrefs.GetFloat("LevelSpeed", 1) * 100).ToString();
        _textPriseDamage.text = (PlayerPrefs.GetFloat("LevelDamage", 1) * 1000).ToString();
    }
    public void UpHealth()
    {
        _temp = (PlayerPrefs.GetFloat("LevelHealth", 1) * 100000);
        if (PlayerPrefs.GetFloat("Crystals", 0) >= _temp)
        {
            PlayerPrefs.SetFloat("Crystals", PlayerPrefs.GetFloat("Crystals", 0) - _temp);
            PlayerPrefs.SetFloat("LevelHealth", PlayerPrefs.GetFloat("LevelHealth", 1) + 1);
        }
    }
    public void UpSpeed()
    {
        _temp = (PlayerPrefs.GetFloat("LevelSpeed", 1) * 100000);
        if (PlayerPrefs.GetFloat("Crystals",0) >= _temp)
        {
            PlayerPrefs.SetFloat("Crystals", PlayerPrefs.GetFloat("Crystals", 0)-_temp);
            PlayerPrefs.SetFloat("LevelSpeed", PlayerPrefs.GetFloat("LevelSpeed", 1) + 1);
        }
    }
    public void UpDamage()
    {
        _temp = (PlayerPrefs.GetFloat("LevelDamage", 1) * 100000);
        if (PlayerPrefs.GetFloat("Crystals", 0) >= _temp)
        {
            PlayerPrefs.SetFloat("Crystals", PlayerPrefs.GetFloat("Crystals", 0) - _temp);
            PlayerPrefs.SetFloat("LevelDamage", PlayerPrefs.GetFloat("LevelDamage", 1) + 1);
        }
    }
}

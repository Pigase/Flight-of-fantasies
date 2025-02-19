using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpParametars : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textLevelHealth;
    [SerializeField] private TextMeshProUGUI _textLevelSpeed;
    [SerializeField] private TextMeshProUGUI _textLevelDamage;

    public void UpHealth()
    {
        PlayerPrefs.SetFloat("LevelHealth",PlayerPrefs.GetFloat("LevelHealth",1)+1);
    }
    public void UpSpeed()
    {
        PlayerPrefs.SetFloat("LevelSpeed", PlayerPrefs.GetFloat("LevelSpeed", 1) + 1);
    }
    public void UpDamage()
    {
        PlayerPrefs.SetFloat("LevelDamage", PlayerPrefs.GetFloat("LevelDamage", 1) + 1);
    }
}

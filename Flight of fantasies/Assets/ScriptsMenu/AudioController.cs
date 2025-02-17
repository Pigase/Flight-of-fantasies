using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource[] m_Source;
    [SerializeField] private Scrollbar _scroll;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private string _KeySound;

    private float value;

    private void Start()
    {
        LoadValue();
        Value();
    }
    public void Toggle()
    {
        if(!_toggle.isOn)
            value = 0;
        if (_toggle.isOn)
            value = 1;

        SaveValue();
        Value();
    }

    public void Scroll()
    {
        value = _scroll.value;

        Value();
        SaveValue();
    }

    private void Value()
    {
        for(int i = 0; i < m_Source.Length; i++)
        {
            m_Source[i].volume = value;
        }
        _scroll.value = value;
        if(value == 0) {_toggle.isOn = false;}else { _toggle.isOn = true;}
    }

    private void SaveValue()
    {
        PlayerPrefs.SetFloat(_KeySound, value);
    }

    private void LoadValue()
    {
        value = PlayerPrefs.GetFloat(_KeySound, value);
    }


}

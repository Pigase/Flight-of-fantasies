using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnableAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _clip;
    [SerializeField] private string _clipName;

    public void StartClip()
    {
        Animator animator = _clip?.GetComponent<Animator>();

        animator?.SetTrigger(_clipName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseUpButton : MonoBehaviour
{
    [SerializeField] private Button[] _buttonsChooseUp;

    private float minPosY;
    private float maxPosY;

    public void Click()
    {
        minPosY = transform.position.y;
        maxPosY = transform.position.y;

        for (int i = 0; i < _buttonsChooseUp.Length; i++)
        {
            if (_buttonsChooseUp[i].transform.position.y > maxPosY) 
            { 
                maxPosY = _buttonsChooseUp[i].transform.position.y; 
            }
            else 
            { 
                minPosY = _buttonsChooseUp[i].transform.position.y;
            }           
        }

        if (transform.position.y <= minPosY)
        {
            Debug.Log(transform.position);

            for (int i = 0; i < _buttonsChooseUp.Length; i++)
            {
                _buttonsChooseUp[i].transform.position = new Vector3(_buttonsChooseUp[i].transform.position.x,transform.position.y , 0);
            }
            transform.position = new Vector3(transform.position.x, maxPosY, 0);
        }

    }
}

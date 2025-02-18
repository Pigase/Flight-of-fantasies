using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textPoints;
    [SerializeField] private GameManipulator _gameManipulator;
    [SerializeField] private float pointsToView = 0;

    private void Update()
    {
      PointsCounter();
    }
    private void PointsCounter()
    {
        pointsToView = _gameManipulator._Points;
        _textPoints.text = pointsToView.ToString();
    }
}

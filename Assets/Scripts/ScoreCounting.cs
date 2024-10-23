using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public enum ScoreType
{
    Perfect = 0,
    Great = 1,
    Good = 2,
    Cool = 3
}

public class ScoreCounting : MonoBehaviour
{
    [SerializeField] private UnityEvent<int, ScoreType> updateScoreAction;

    private Vector2 _perfectPointLine;
    private int _score;

    public void ClearScore()
    {
        _score = 0;
        updateScoreAction?.Invoke(_score, ScoreType.Perfect);
    }

    public void ScoreCalculate(Vector3 notePosition)
    {
        ScoreType scoreType;
        var score = 0;
        switch (Mathf.Abs(notePosition.y - transform.position.y))
        {
            case < 1f:
                scoreType = ScoreType.Perfect;
                score = 5;
                break;
            case >= 1f and < 2f:
                scoreType = ScoreType.Great;
                score = 3;
                break;
            case >= 2f and < 4f:
                scoreType = ScoreType.Good;
                score = 2;
                break;
            default:
                score = 1;
                scoreType = ScoreType.Cool;
                break;
        }
        
        _score += score;
        updateScoreAction?.Invoke(_score, scoreType);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private int _lives=3;
    [Range(3,5)] private int _maxLives = 5;
    private int simpleBrickDestroyCoefficient = 100;
    private LivesBar _livesBar;
    private ScoreBar _scoreBar;
    private Ball _ball;

     // public void SetLives(int incomingValue) => _lives = incomingValue;
    //public int GetLives() => _lives;
    //public void SetLives(int incomingValue)
    //{
    //    _lives = Mathf.Clamp(incomingValue, 0, _maxLives);
    //}

    public int Lives
    {
        get => _lives;
        //set => _lives = Mathf.Clamp(value, 0, _maxLives); //don't delete.  
        set
           {
            _lives = Mathf.Clamp(value, 0, _maxLives);
             OnLivesChanged();
           }
    }
    public void ScoreHandler(int value)
    {
        if (value == 0)
        {
            _score += simpleBrickDestroyCoefficient;
            OnScoreChanged(_score);
        }
    }

    private void OnScoreChanged(int value)
    {
        _scoreBar.Refresh(value);
    }
    private void OnLivesChanged()
    {
        _livesBar.Refresh();
    }

   
    void Start()
    {
        _scoreBar._scoreText.text = _score.ToString();
        //_scoreText.text = _score.ToString();
    }

    private void Awake()
    {
        _livesBar = FindObjectOfType<LivesBar>();
        _scoreBar = FindObjectOfType<ScoreBar>();
        _ball = FindObjectOfType<Ball>();
    }
   
    void Update()
    {
        
    }
}

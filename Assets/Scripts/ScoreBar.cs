using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    private GameManager _gameManager;
    private Ball _ball;

    public Text _scoreText;
    void Start()
    {
        
    }
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    public void Refresh(int incomingScore)
    {
        _scoreText.text = incomingScore.ToString();
    }
    void Update()
    {
        
    }
}

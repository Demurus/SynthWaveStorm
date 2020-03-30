using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    private GameManager _gameManager;
    private DepenciesManager _depenciesManager;
    
    public Text _scoreText;
    public Text _highScoreText;
    void Start()
    {
        
    }
    private void Awake()
    {
        _depenciesManager = FindObjectOfType<DepenciesManager>();
        _gameManager = _depenciesManager.gameManager;
    }
    public void Refresh(int incomingScore)
    {
        _scoreText.text = incomingScore.ToString();
    }

    public void RefreshHighScore(int incomingScore)
    {
        _highScoreText.text = incomingScore.ToString();
    }
    void Update()
    {
        
    }
}

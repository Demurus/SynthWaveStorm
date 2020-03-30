using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepenciesManager : MonoBehaviour
{
    public GameManager gameManager;
    public PowerUpManager powerUpManager;
    public AudioManager audioManager;
    public LivesBar livesBar;
    public ScoreBar scoreBar;
    public Coinbar coinBar;
    public Ball ball;
    public PlayerBehaviour playerBehaviour;
  

    private void Awake()
    {
        
    }
}

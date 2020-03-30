using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private int _lives;

    private int _playerLevelCoins;
    private int _playerAllCoins;
    private int _playerHighScore;
   


    [Range(3,5)] private int _maxLives = 5;
    private int _bricksCount;
    private LivesBar _livesBar;
    private ScoreBar _scoreBar;
    private Coinbar _coinBar;
    private AudioManager _audioManager;
    private DepenciesManager _depenciesManager;
    private PlayerBehaviour _playerBehaviour; 
    private Ball _ball;
    private Coin _coin;
    private LostLevelWindow _lostLevelWindow;
    private ShopWindow _shopWindow;

   [Range(0,2)] [SerializeField] private float _dropCoefficient=1.0f;
    private int _coinDropChance;
    public event Action GameOverWonEvent;
    public event Action GameOverLostEvent;
    public event Action OnHighScoreChangedEvent;

    private void Awake()
    {
        _depenciesManager = FindObjectOfType<DepenciesManager>();
        _livesBar = _depenciesManager.livesBar;
        _scoreBar = _depenciesManager.scoreBar;
        _coinBar = _depenciesManager.coinBar;
        _ball = _depenciesManager.ball;
       
        _coin = Resources.Load<Coin>("Coin");
        _playerBehaviour = _depenciesManager.playerBehaviour;
        _audioManager = _depenciesManager.audioManager;
      

    }

    public int PlayerLevelCoins
    {
        get => _playerLevelCoins;
        
        set
        {
            _playerLevelCoins = value;
        }
    }
    public int PlayerAllCoins
    {
        get => _playerAllCoins;
        
        set
        {
            _playerAllCoins = value;
        }
    }

    public int PlayerHighScore
    {
        get => _playerHighScore;
        set
        {
            _playerHighScore = value;
        }
    }

    private void PlayerCoin50() //тут должна быть интовый метод с параметром количества купленных монет
    {
        PlayerAllCoins += 50;

    }
    public int Lives
    {
        get => _lives;
        
        set
        {
            _lives = Mathf.Clamp(value, 0, _maxLives);
            OnLivesChanged();
        }
    }
   


    void Start()
    {
        PlayerLevelCoins = _playerBehaviour._coins;
        _coinBar.Refresh(PlayerLevelCoins);
        PlayerHighScore = _playerBehaviour._highscore;
        _scoreBar._highScoreText.text = PlayerHighScore.ToString();
        OnScoreChanged(_score);
        _bricksCount = GameObject.FindGameObjectsWithTag(TagClass.BrickblueSimpleBrick).Length + GameObject.FindGameObjectsWithTag(TagClass.BrickpurpleSimpleBrick).Length+ GameObject.FindGameObjectsWithTag(TagClass.BrickpurpleStrongBrick).Length+ GameObject.FindGameObjectsWithTag(TagClass.BrickblueStrongBrick).Length+ GameObject.FindGameObjectsWithTag(TagClass.BrickarmoredBrick).Length;
        Debug.Log(_bricksCount);
    }


   

    public void OnCoinsChanged()
    {
        PlayerLevelCoins++;
        _coinBar.Refresh(PlayerLevelCoins);
    }
    
    public int CoinDropChance(string brickTag)
    {
        if (brickTag == TagClass.BrickblueSimpleBrick || brickTag == TagClass.BrickpurpleSimpleBrick)
        {
            return _coinDropChance = (int) Mathf.Round(20 * _dropCoefficient);
        }
        if (brickTag== TagClass.BrickblueStrongBrick || brickTag == TagClass.BrickpurpleStrongBrick)
        {
            return _coinDropChance = (int)Mathf.Round(50 * _dropCoefficient);
        }
        if (brickTag == TagClass.BrickarmoredBrick)
        {
            return _coinDropChance = (int)Mathf.Round(80 * _dropCoefficient);
        }
        else return 0;
    }

    public void SpawnCoin(Vector3 position, string brickTag)
    {
        int random = UnityEngine.Random.Range(1, 101);
        if ((CoinDropChance(brickTag)+random)>80)
        {
            Instantiate(_coin, position, Quaternion.identity);
        }
       
        
    }
    public void LivesChanger()
    {
        Lives--;
    }
    
    public void BricksCountRefresh()
    {
        _bricksCount--;
        Debug.Log(_bricksCount);
        if (_bricksCount<=0)
        {
            OnGameOverWon();
        }
    }

    public void OnGameOverWon()
    {
        Debug.Log("won");
        PlayerAllCoins += PlayerLevelCoins;
        GameOverWonEvent?.Invoke();
    }
    public void OnGameOverLost()
    {
        Debug.Log("lost");
        _audioManager.Play(TagClass.SoundGameIsLost);
        GameOverLostEvent?.Invoke();
      
    }

   
    public void ScoreHandler(int incomingScore)
    {
        _score += incomingScore;
         OnScoreChanged(_score);
        if (_score > PlayerHighScore)
        {
            OnHighScoreCnanged();
        }


    }
    public void OnHighScoreCnanged()
    {
        OnHighScoreChangedEvent?.Invoke();
            PlayerHighScore = _score;
            _scoreBar.RefreshHighScore(PlayerHighScore);
       
        
    }
    private void OnScoreChanged(int value)
    {
        _scoreBar.Refresh(value);
    }
    private void OnLivesChanged()
    {
        _livesBar.Refresh();
        if (_lives <= 0) OnGameOverLost();
    }

   
}

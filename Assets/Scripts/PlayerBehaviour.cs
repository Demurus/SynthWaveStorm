using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int _coins;
    public int _highscore;

    private GameManager _gameManager;
    private DepenciesManager _depenciesManager;

    private void Awake()
    {
        _depenciesManager = FindObjectOfType<DepenciesManager>();
        LoadPlayerState();
        _gameManager = _depenciesManager.gameManager;
        _gameManager.OnHighScoreChangedEvent += UpdateHighScore;
        _gameManager.GameOverWonEvent += SavePlayerState;
    }
    void Start()
    {
        
        
    }

    public void UpdateHighScore()
    {
        _highscore = _gameManager.PlayerHighScore;
        Debug.Log(_highscore);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
           
            SavePlayerState();
        }
    }

    private const string PlayerStateKey = "PlayerState";
    private void SavePlayerState()
    {
        _coins = _gameManager.PlayerAllCoins;
        PlayerState playerState = new PlayerState()
        {
            Coins = _coins,
            HighScore = _highscore,
        };

        string playerStateJSON = JsonUtility.ToJson(playerState, true);

        File.WriteAllText("D://PlayerDataState.json", playerStateJSON);
        PlayerPrefs.SetString(PlayerStateKey, playerStateJSON);
        Debug.Log($"PlayerState: {playerStateJSON}");
        Debug.Log($"Path: {Application.persistentDataPath}");
    }

    private void LoadPlayerState()
    {
        if (!PlayerPrefs.HasKey(PlayerStateKey))
            return;

        string json = PlayerPrefs.GetString(PlayerStateKey);
        Debug.Log($"PlayerState loaded: {json}");
        PlayerState playerState = JsonUtility.FromJson<PlayerState>(json);

        _coins = playerState.Coins;
        _highscore = playerState.HighScore;
       

       
    }
}

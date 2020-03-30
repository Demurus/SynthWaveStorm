using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _ballSpeed;
    [SerializeField] private Transform _ballSpawnPosition;
    private Rigidbody2D _rigidbody;
    private GameManager _gameManager;
    private PowerUpManager _powerUpManager;
    private bool _ballIsStarted = false;
    private bool gameisOver = false;
    private AudioManager _audioManager;
    private DepenciesManager _depenciesManager;



    private void Awake()
    {
        _depenciesManager = FindObjectOfType<DepenciesManager>();
        _gameManager =_depenciesManager.gameManager;
        _powerUpManager = _depenciesManager.powerUpManager;
        _audioManager = _depenciesManager.audioManager;
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameManager.GameOverLostEvent += GameOverChecker;
        _gameManager.GameOverWonEvent += GameOverChecker;
        _powerUpManager.OnBallSpeedUpEvent += BallSpeedUp;
    }
    void Start()
    {

    }
    private void Update()
    {
        if(_ballIsStarted||gameisOver) { return; }

        else this.transform.position = _ballSpawnPosition.transform.position;

    }

    void FixedUpdate()
    {
        if (_ballIsStarted || gameisOver) return;
       
        
        if (Input.GetButtonDown("Jump"))
        {
            StartTheBall();
        }
      
    }

    private void BallSpeedUp()
    {
        _rigidbody.AddForce(_rigidbody.velocity * 10);
    }

    private void GameOverChecker()
    {
        gameisOver = true;

    }
    private void StartTheBall()
    {     
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(new Vector2(_ballSpeed, _ballSpeed));
        
        _ballIsStarted = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Deadzone"))
        {
             _rigidbody.velocity = Vector3.zero;
            _gameManager.LivesChanger();
            Debug.Log(_gameManager.Lives);
            _ballIsStarted = false;
        }
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Brick brick = collision.transform.GetComponent<Brick>();
        if (brick)
        {
            if (brick.HealthHandler(collision.collider.tag) == true)
            {
                brick.CollapseColour(collision.collider.tag);
                _gameManager.ScoreHandler(brick.ScoreOnDestroy());
                _audioManager.Play(TagClass.SoundStandardHit);
                int random = Random.Range(0, 11);
                if (random > 5)
                {
                    _powerUpManager.SpawnPowerup(collision.transform.position);
                }
                 else
                 {
                    _gameManager.SpawnCoin(collision.transform.position, collision.collider.tag);
                 }

                _gameManager.BricksCountRefresh();
                Destroy(collision.gameObject);
            }
            else return;
        }
        if (!brick)
        {
            _audioManager.Play(TagClass.SoundWallHit);
        }
           
    }

   
}


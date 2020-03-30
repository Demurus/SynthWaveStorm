using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _xAxisBorder;
    [SerializeField] private List<GameObject> _paddleList;
    private Vector3 _direction;
    private Vector3 _positionX;
    private GameManager _gameManager;
    private DepenciesManager _depenciesManager;
    private PowerUpManager _powerUpManager;
    private bool gameisOver = false;
    private int _paddleSize;
    private int _defaultPaddleSize = 2;
    public int PaddleSize
    {
        get => _paddleSize;
        //set => _lives = Mathf.Clamp(value, 0, _maxLives); //don't delete.  
        set
        {
            _paddleSize = Mathf.Clamp(value, 0, 4);
        }
    }


    private void Start()
    {
        PaddleSize = _defaultPaddleSize;
        
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _depenciesManager = FindObjectOfType<DepenciesManager>();
        _gameManager = _depenciesManager.gameManager;
        _powerUpManager = _depenciesManager.powerUpManager;
        _gameManager.GameOverLostEvent += GameOverChecker;
        _gameManager.GameOverWonEvent += GameOverChecker;
        _powerUpManager.OnPaddeGrowEvent += PaddleGrow;
        _powerUpManager.OnPaddeShrinkEvent += PaddleShrink;
    }
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
       

        if (Input.GetButton("Horizontal"))
        {
            PaddleMove();
        }
    }

    private void PaddleGrow()
    {
        PaddleSize++;
        Debug.Log("new grow " + _paddleSize);
        PaddleSizeManager(PaddleSize);
        
    }

    private void PaddleShrink()
    {

        PaddleSize--;
       
        Debug.Log("new shrink " + _paddleSize);
        PaddleSizeManager(PaddleSize);
        
    }
    public void PaddleSizeManager(int incomingValue)
    {
        int _newPaddleSize = Mathf.Clamp(incomingValue, 0, 4);
            Debug.Log("clamped paddlesize" +_newPaddleSize);
            Hide(_paddleList[_defaultPaddleSize]);
            Show(_paddleList[_newPaddleSize]);
            _defaultPaddleSize = _newPaddleSize;
        Debug.Log("defaultsize" + _defaultPaddleSize);

        

    }
    private void Show(GameObject paddle)
    {
        paddle.SetActive(true);
    }
    private void Hide(GameObject paddle)
    {
        paddle.SetActive(false);
    }
    private void GameOverChecker()
    {
        gameisOver = true;
       
    }
    private void PaddleMove()
    {
        if (gameisOver) { return; }
        else {

            _direction = transform.right * Input.GetAxis("Horizontal");
            transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
            _positionX = transform.position;
            _positionX.x = Mathf.Clamp(_positionX.x, -_xAxisBorder, _xAxisBorder);
            transform.position = _positionX;
        }
    }
}

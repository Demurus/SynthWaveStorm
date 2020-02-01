using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _ballSpeed;
    [SerializeField] private Transform _ballSpawnPosition;
    //[SerializeField] private GameObject _brickCollapse;
    private Rigidbody2D _rigidbody;
    private bool _ballIsStarted = false;
    private Brick brick;
    private GameManager _gameManager;
    


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameManager = FindObjectOfType<GameManager>();
    }
    void Start()
    {

    }
    private void Update()
    {
        if(_ballIsStarted)
        { return; }
        else this.transform.position = _ballSpawnPosition.transform.position;

    }

    void FixedUpdate()
    {
       
        if (Input.GetButtonDown("Jump") && !_ballIsStarted)
        {
            StartTheBall();
        }
    }

    private void StartTheBall()
    {
        // transform.SetParent(null);
        
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(new Vector2(_ballSpeed, _ballSpeed));
        _ballIsStarted = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Deadzone"))
        {
             _rigidbody.velocity = Vector3.zero;

            // this.transform.position = _ballSpawnPosition.transform.position;
            _gameManager.Lives--;
            Debug.Log(_gameManager.Lives);
            _ballIsStarted = false;
        }
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("blueBrick")|| collision.collider.CompareTag("purpleBrick"))
        {
            //Instantiate(_brickCollapse, collision.transform.position, collision.transform.rotation);
            //brick = GetComponent<Brick>().Collapse();
            collision.transform.GetComponent<Brick>().CollapseColour(collision.collider.tag);
            //BrickTypeHit(0);
            _gameManager.ScoreHandler(0);
            //collision.transform.GetComponent<Brick>().BlueCollapse();
            // collision.transform.GetComponent<Brick>().Collapse();


            Destroy(collision.gameObject);
        }
    }
}


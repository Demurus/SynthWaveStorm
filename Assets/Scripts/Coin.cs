using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private CoinManager _coinManager;
    private GameManager _gameManager;
    private int _coinValue=250;
    private AudioManager _audioManager;
    private DepenciesManager _depenciesManager;


    private void Awake()
    {
        _depenciesManager = FindObjectOfType<DepenciesManager>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameManager = _depenciesManager.gameManager;
        _audioManager = _depenciesManager.audioManager;
       
    }

       void Start()
    {
        _rigidbody.AddForce(new Vector2(0, 50F));

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagClass.Paddle))
        {
            _gameManager.OnCoinsChanged();
            _gameManager.ScoreHandler(_coinValue);
            int random = Random.Range(1, 3);
            _audioManager.Play("CoinsPickup"+random);
            Destroy(gameObject);
        }
        if (collision.CompareTag(TagClass.DeadZone))
        {
            _rigidbody.velocity = Vector3.zero;
            Destroy(gameObject);
        }
    }
}

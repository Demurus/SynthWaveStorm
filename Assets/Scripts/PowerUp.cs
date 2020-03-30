using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    private Rigidbody2D _rigidbody;
    private PowerUpManager _powerUpManager;
    private AudioManager _audioManager;
    private DepenciesManager _depenciesManager;

    private void Awake()
    {
        _depenciesManager = FindObjectOfType<DepenciesManager>();
        _powerUpManager = _depenciesManager.powerUpManager;
        _audioManager = _depenciesManager.audioManager;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rigidbody.AddForce(new Vector2(0, 50F));
    }

   
    void FixedUpdate()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag(TagClass.Paddle))
        {
            
            _powerUpManager.PowerUpHandler(tag);
            _audioManager.Play(TagClass.SoundPowerUp);
            Destroy(gameObject);
        }
        if (collision.CompareTag(TagClass.DeadZone))
        {
            _rigidbody.velocity = Vector3.zero;
            Destroy(gameObject);
        }
    }
   
}

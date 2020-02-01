using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _xAxisBorder;
    private Vector3 _direction;
    private Vector3 _positionX;

    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
       
    }

    
    void FixedUpdate()
    {
       

        if (Input.GetButton("Horizontal"))
        {
            PaddleMove();
        }
    }

    private void PaddleMove()
    {
        _direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed*Time.deltaTime);
        _positionX = transform.position;
        _positionX.x=Mathf.Clamp(_positionX.x, -_xAxisBorder, _xAxisBorder);
        transform.position = _positionX;

       
       
        

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";
    private Rigidbody2D _rb2d;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _input;
    private bool _isWalking;

    [SerializeField] private float _speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis(_horizontalAxis);
        float verticalInput = Input.GetAxis(_verticalAxis);

        _input = new Vector2(horizontalInput, verticalInput);
        _input.Normalize();
    }

    private void FixedUpdate()
    {
        Move();
        FlipSprite();
    }

    private void FlipSprite()
    {
        if (_input.x != 0)
        {
            _spriteRenderer.flipX = _input.x < 0; // control the flip sprite by making input less then 0 so true, then flip else not flip
        }
    }

    private void Move()
    {
        Vector2 velocity = new Vector2(_input.x * _speed * Time.deltaTime, _rb2d.velocity.y);
        _rb2d.velocity = velocity;
        _isWalking = _input.magnitude > 0;
    }

	public bool IsWalking() => _isWalking;
    
}
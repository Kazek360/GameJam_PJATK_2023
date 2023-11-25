using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;
    private GameObject _food;
    private Hand _hand;
    [SerializeField] private float _playerMovementSpeed;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _hand = GetComponentInChildren<Hand>();
    }

    
    private void Update()
    {
        //player movement left/right
        var horizontalInput = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(horizontalInput * _playerMovementSpeed, _rigidbody2D.velocity.y);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            if (_food == null)
            {
                _food = other.gameObject;
                _food.SetActive(false);
                _hand.PickUpFood(_food);
            }
        }
    }
    
}

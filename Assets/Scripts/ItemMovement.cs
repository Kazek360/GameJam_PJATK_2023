using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private bool _isColliding;

    private float _playerRotation;

    private float _fuel;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Wall"))
        {
            _playerRotation += 180;
            transform.rotation = Quaternion.Euler(0, 0, _playerRotation);
            _rigidbody.AddForce(transform.up * 5 * Time.deltaTime,
                ForceMode2D.Impulse);
        }
        _rigidbody.AddForce(transform.up * 5 * Time.deltaTime,
                ForceMode2D.Impulse);
    }

/*    private void OnTriggerEnter2D(Collision2D collision)
    {
        
        _isColliding = true;
        if (collision.CompareTag("XD"))
        {

        }
    }*/
}

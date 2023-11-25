using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    
    private GameObject _food;
    [SerializeField] private float _throwForce;
    [SerializeField] private Transform _throwPoint;
    [SerializeField] private GameObject _point;
    [SerializeField] private int _numberOfPoints;
    [SerializeField] private float _spaceBetweenPoints;
    private GameObject[] _points;
    private Vector2 _direction;
    private Color _gizmosColor;
    private Camera _mainCamera;
    [SerializeField] private float _maxThrowAngle;
    private bool _isFoodNotNull;
    private Rigidbody2D _foodRigidbody;

    private void Start()
    {
        _isFoodNotNull = _food != null;
        _mainCamera = FindObjectOfType<Camera>();
        if (_mainCamera == null)
        {
            Debug.LogError("Main camera not found in the scene.");
        }

        _points = new GameObject[_numberOfPoints];
        for (int i = 0; i < _numberOfPoints; i++)
        {
            _points[i] = Instantiate(_point, _throwPoint.position, Quaternion.identity);
            _points[i].SetActive(false);
        }
    }

    
    private void Update()
    {
        
        UpdateHeldFoodPosition();
        
        Vector2 throwPosition = transform.position;
        Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _direction = mousePosition - throwPosition;
        
        float throwAngle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        throwAngle = Mathf.Clamp(throwAngle, -_maxThrowAngle, _maxThrowAngle);
        _direction = Quaternion.Euler(0, 0, throwAngle) * Vector2.right;

        if (Input.GetButton("Fire2"))
        {
            for (int i = 0; i < _numberOfPoints; i++)
            {
                _points[i].SetActive(true);
                _points[i].transform.position = PointPosition(i * _spaceBetweenPoints);
            }
        }

        if (Input.GetButtonUp("Fire2"))
        {
            for (int i = 0; i < _numberOfPoints; i++)
            {
                _points[i].SetActive(false);
            }
            Throw();
        }
    }
    private void UpdateHeldFoodPosition()
    {
        if (_isFoodNotNull)
        {
            _food.transform.position = _throwPoint.position;
        }
    }
    
    public void PickUpFood(GameObject food)
    {
        _food = food;
        _foodRigidbody = _food.GetComponent<Rigidbody2D>();
        _food.transform.position = _throwPoint.position;
        _isFoodNotNull = true;
    }
    
    private void ResetFood()
    {
        _food = null;
        _isFoodNotNull = false;
        _foodRigidbody = null;
    }
    
    private void Throw()
    {
        if (_isFoodNotNull)
        {
            _foodRigidbody.velocity = _direction.normalized * _throwForce;
            ResetFood();
        }
    }
    
    private Vector2 PointPosition(float t)
    {
        var position = (Vector2)_throwPoint.position + _direction.normalized * t;
        return position;
    }
    
    private void OnDrawGizmos()
    {
        _gizmosColor = Color.red;
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(transform.position, .1f);
    }
    
}

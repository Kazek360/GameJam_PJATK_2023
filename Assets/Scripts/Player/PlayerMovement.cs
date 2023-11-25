using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;

    private Rigidbody2D _rigidbody;

    private bool _isColliding;

    private float _playerRotation;

    private float _fuel;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        PlayerEvents.OnFuelRefill += RefillFuel;
    }

    private void Start()
    {
        _fuel = _playerConfig.startFuel;
    }

    private void Update()
    {
        ChangeRotation();
        MovePlayer();
        WallBounce();
    }

    private void OnDestroy()
    {
        PlayerEvents.OnFuelRefill -= RefillFuel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rigidbody.velocity = Vector2.zero;
        _isColliding = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isColliding = false;
    }

    private void ChangeRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _playerRotation += _playerConfig.rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            _playerRotation -= _playerConfig.rotationSpeed * Time.deltaTime;
        }
        transform.rotation = Quaternion.Euler(0, 0, _playerRotation);
    }

    private void WallBounce()
    {
        if (Input.GetKeyDown(KeyCode.S) && _isColliding)
        {
            _playerRotation += 180;
            transform.rotation = Quaternion.Euler(0, 0, _playerRotation);
            _rigidbody.AddForce(transform.up * _playerConfig.bouncePower, ForceMode2D.Impulse);
        }
    }

    private void MovePlayer()
    {
        if(_fuel > 0)
        {
            _rigidbody.AddForce(transform.up * Input.GetAxis("Move") * _playerConfig.speed * Time.deltaTime, 
                ForceMode2D.Impulse);
            _fuel -= Mathf.Abs(_rigidbody.velocity.magnitude) * _playerConfig.fuelUsage * Time.deltaTime;
            Debug.Log($"Fuel:{_fuel}");
        }
        _rigidbody.velocity *= 0.997f;
    }

    private void RefillFuel()
    {
        _fuel = _playerConfig.startFuel;
        Debug.Log($"Fuel:{_fuel}");
    }

}

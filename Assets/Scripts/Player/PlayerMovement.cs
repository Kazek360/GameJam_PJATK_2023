using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;

    private Rigidbody2D _rigidbody;

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
        UpdateFuel();
    }

    private void OnDestroy()
    {
        PlayerEvents.OnFuelRefill -= RefillFuel;
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

    private void MovePlayer()
    {
        if(_fuel > 0)
        {
            _rigidbody.AddForce(transform.up * Input.GetAxis("Move") * _playerConfig.speed * Time.deltaTime, 
                ForceMode2D.Impulse);
        }
        _rigidbody.velocity *= 0.997f;
    }

    private void UpdateFuel()
    {
        _fuel -= Mathf.Abs(_rigidbody.velocity.magnitude) * _playerConfig.fuelUsage * Time.deltaTime;

        Debug.Log($"Fuel:{_fuel}");
    }

    private void RefillFuel()
    {
        _fuel = _playerConfig.startFuel;
        Debug.Log($"Fuel:{_fuel}");
    }

}

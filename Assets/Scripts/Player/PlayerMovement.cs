using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;

    private Rigidbody2D _rigidbody;

    private float _playerRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ChangeRotation();
        MovePlayer();
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
        Vector2 ruch = transform.up * Input.GetAxis("Move") * _playerConfig.speed * Time.deltaTime;

        _rigidbody.AddForce(ruch, ForceMode2D.Impulse);

        _rigidbody.velocity *= 0.997f;
    }
}

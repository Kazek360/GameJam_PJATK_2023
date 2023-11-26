using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _config;

        private Rigidbody2D _rigidbody;
        private Hand _hand;

        private bool _isColliding;

        private float _playerRotation;


        private float _fuelValue;

        private float _fuel
        {
            get => _fuelValue;
            set
            {
                _fuelValue = value;
                PlayerEvents.UpdateFuel(value);
            }
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _hand = GetComponentInChildren<Hand>();
            PlayerEvents.OnFuelRefill += RefillFuel;
        }

        private void Start()
        {
            _fuel = _config.startFuel;
        }

        private void Update()
        {
            ChangeRotation();
            MovePlayer();
            WallBounce();
            CatchFood();
        }
        
        public void CatchFood()
        {
            Collider2D[] foodInRange = Physics2D.OverlapCircleAll(
                _hand.CatchZone.position,
                _hand.CatchZoneRange,
                _hand.FoodLayerMask
            );
        
            if (foodInRange.Length > 0)
            {
                foreach (Collider2D foodCollider in foodInRange)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        _hand.PickUpFood(foodCollider.gameObject);
                    }
                }
            }
        }

        private void OnDestroy()
        {
            PlayerEvents.OnFuelRefill -= RefillFuel;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
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
                _playerRotation += _config.rotationSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.E))
            {
                _playerRotation -= _config.rotationSpeed * Time.deltaTime;
            }
            transform.rotation = Quaternion.Euler(0, 0, _playerRotation);
        }

        private void WallBounce()
        {
            if (Input.GetKeyDown(KeyCode.S) && _isColliding)
            {
                _playerRotation += 180;
                transform.rotation = Quaternion.Euler(0, 0, _playerRotation);
                _rigidbody.AddForce(transform.up * _config.bouncePower, ForceMode2D.Impulse);
            }
        }

        private void MovePlayer()
        {
            if(_fuel > 0)
            {
                if (Input.GetAxis("Move") > 0)
                {
                    _fuel -= Mathf.Abs(_rigidbody.velocity.magnitude) * _config.fuelUsage * Time.deltaTime;
                }
                _rigidbody.AddForce(transform.up * Input.GetAxis("Move") * _config.speed * Time.deltaTime, 
                    ForceMode2D.Impulse);
            
            }
        }

        private void RefillFuel()
        {
            _fuel = _config.startFuel;
        }

    }
}

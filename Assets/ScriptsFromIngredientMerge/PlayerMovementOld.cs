using UnityEngine;

namespace ScriptsFromIngredientMerge
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementOld : MonoBehaviour
    {

        private Rigidbody2D _rigidbody2D;
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
    
        /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            if (_hand.IsFoodNotNull)
            {
                return;
            }
            _hand.PickUpFood(other.gameObject);
        }
    }
    */
    
    }
}

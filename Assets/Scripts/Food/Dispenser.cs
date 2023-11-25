using UnityEngine;

public class Dispenser : MonoBehaviour
{
    [SerializeField] private FoodShooterConfig _config;
    [SerializeField] private GameObject[] _foodTypes;
    [SerializeField] private Transform shootPosition;
    private float _cooldownToShoot;

    private void Start()
    {
        _cooldownToShoot = 0;
    }

    private void Update()
    {
        if (Time.time >= _cooldownToShoot)
        {
            if (Random.value < 0.25)
            {
                ShootRandomFood();
            }        
        }
    }

    void ShootRandomFood()
    {
        GameObject food = Instantiate(_foodTypes[Random.Range(0, _foodTypes.Length)], shootPosition.position, 
            Quaternion.identity);

        Rigidbody2D foodRigidbody = food.GetComponent<Rigidbody2D>();
        if (foodRigidbody != null)
        {
            foodRigidbody.velocity = shootPosition.up * _config.shootPower;
        }

        _cooldownToShoot = Time.time + _config.cooldown;
    }
}
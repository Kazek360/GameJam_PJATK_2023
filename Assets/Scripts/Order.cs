using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField] private Transform recipe;
    [SerializeField] private GameObject[] _recipies;
    private string recipeName;
    private GameObject alienOrder;

    void Start()
    {
        int index = Random.Range(0, _recipies.Length);
        alienOrder = Instantiate(_recipies[index], recipe.position,
            Quaternion.identity);
        switch (index)
        {
            case 0:
                recipeName = "SnotSalad";
                break;
            default:
                recipeName = "SnotSalad";
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(recipeName))
        {
            PlayerEvents.CompleteOrder();
            Destroy(alienOrder);
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
}

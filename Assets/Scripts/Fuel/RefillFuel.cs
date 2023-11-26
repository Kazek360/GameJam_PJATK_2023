using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillFuel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.Play("Refuel");
            PlayerEvents.RefillFuel();
        }
    }
}

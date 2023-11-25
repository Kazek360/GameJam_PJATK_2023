using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    public void Awake()
    {
        PlayerEvents.OnFuelUpdate += SetFuel;
    }
    public void SetMaxFuel(float fuel)
    {
        _slider.maxValue = fuel;
        _slider.value = fuel;
    }

    public void SetFuel(float currentFuelAmount)
    {
        _slider.value = currentFuelAmount;
    }
}

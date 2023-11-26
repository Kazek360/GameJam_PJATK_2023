using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Dispenser Config", fileName = "DispenserConfig")]
public class FoodShooterConfig : ScriptableObject
{
    public float cooldown;
    public float shootPower;
}

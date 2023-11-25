using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player Config", fileName = "PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public float speed;
    public float bouncePower;
    public float rotationSpeed;

    public float startFuel;
    public float fuelUsage;
}

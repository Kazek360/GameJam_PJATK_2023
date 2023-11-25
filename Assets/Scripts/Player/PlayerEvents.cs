using System;

public static class PlayerEvents
{
    public static event Action<float> OnFuelUpdate;
    public static event Action OnFuelRefill;

    public static void UpdateFuel(float currentFuelAmount)
    {
        OnFuelUpdate?.Invoke(currentFuelAmount);
    }
    public static void RefillFuel()
    {
        OnFuelRefill?.Invoke();
    }
}

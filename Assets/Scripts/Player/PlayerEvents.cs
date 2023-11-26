using System;

public static class PlayerEvents
{
    public static event Action<float> OnFuelUpdate;
    public static event Action OnFuelRefill;
    public static event Action<int> OnScoreUpdate;
    public static event Action OnOrderComplete;

    public static void UpdateFuel(float currentFuelAmount)
    {
        OnFuelUpdate?.Invoke(currentFuelAmount);
    }
    public static void RefillFuel()
    {
        OnFuelRefill?.Invoke();
    }
    public static void UpdateScore(int currentScore)
    {
        OnScoreUpdate?.Invoke(currentScore);
    }
    public static void CompleteOrder()
    {
        OnOrderComplete?.Invoke();
    }
}

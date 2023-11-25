using System;

public static class PlayerEvents
{
    public static event Action OnFuelRefill;

    public static void RefillFuel()
    {
        OnFuelRefill?.Invoke();
    }
}

using UnityEngine;

public class FlightLockManager : MonoBehaviour
{
    public bool canFly = false;

    public void UnlockFlight()
    {
        canFly = true;
        Debug.Log("✅ All buttons clicked. Flight is now enabled.");
    }
}
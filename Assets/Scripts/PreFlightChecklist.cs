using UnityEngine;

public class PreFlightChecklist : MonoBehaviour
{
    public bool beaconChecked = false;
    public bool batteryChecked = false;
    public bool engineChecked = false;

    public bool CanFly => beaconChecked && batteryChecked && engineChecked;

    public void MarkBeaconChecked()  => beaconChecked = true;
    public void MarkBatteryChecked() => batteryChecked = true;
    public void MarkEngineChecked()  => engineChecked = true;
}
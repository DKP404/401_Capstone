using UnityEngine;

public class PreFlightChecklist : MonoBehaviour
{
    [Header("Checklist Toggles")]
    public bool beaconLightOn;
    public bool batterySwitchOn;
    public bool enginesOn;

    public bool AllChecksPassed => 
        beaconLightOn &&
        batterySwitchOn &&
        enginesOn;
}
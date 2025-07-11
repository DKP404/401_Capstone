using UnityEngine;

public class PreFlightChecklist : MonoBehaviour
{
    [Header("Checklist Toggles")]
    public bool beaconLightOn;
    public bool noWarnings;
    public bool airConditioningOn;
    public bool cabinPressureOK;
    public bool radioChecked;
    public bool altimeterSet;
    public bool airspeedIndicatorOK;
    public bool altitudeIndicatorOK;
    public bool flapsSet;
    public bool fuelShutoffOK;
    public bool parkingBrakeOff;
    public bool batterySwitchOn;
    public bool enginesOn;

    public bool AllChecksPassed => 
        beaconLightOn &&
        noWarnings &&
        airConditioningOn &&
        cabinPressureOK &&
        radioChecked &&
        altimeterSet &&
        airspeedIndicatorOK &&
        altitudeIndicatorOK &&
        flapsSet &&
        fuelShutoffOK &&
        parkingBrakeOff &&
        batterySwitchOn &&
        enginesOn;
}
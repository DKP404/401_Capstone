using UnityEngine;
using UnityEngine.UI;

public class PreflightChecklist : MonoBehaviour
{
    public Button beaconButton;
    public Button batteryButton;
    public Button engineButton;

    private bool beaconChecked = false;
    private bool batteryChecked = false;
    private bool engineChecked = false;

    private FlightLockManager flightLock;

    void Start()
    {
        flightLock = FindObjectOfType<FlightLockManager>();

        beaconButton.onClick.AddListener(() => CheckItem("beacon"));
        batteryButton.onClick.AddListener(() => CheckItem("battery"));
        engineButton.onClick.AddListener(() => CheckItem("engine"));
    }

    void CheckItem(string item)
    {
        switch (item)
        {
            case "beacon": beaconChecked = true; break;
            case "battery": batteryChecked = true; break;
            case "engine": engineChecked = true; break;
        }

        CheckAllDone();
    }

    void CheckAllDone()
    {
        if (beaconChecked && batteryChecked && engineChecked)
        {
            flightLock.UnlockFlight();
        }
    }
}
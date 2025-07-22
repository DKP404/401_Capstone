using UnityEngine;

public class StartPreFlightCheck : MonoBehaviour
{
    public GameObject nextPanel;
    public GameObject currentPanel;

    public void OnStartPreFlightCheck()
    {
        nextPanel?.SetActive(true);
    }

    public void AfterPreFlightCheckStart()
    {
        currentPanel?.SetActive(false);
    }
}
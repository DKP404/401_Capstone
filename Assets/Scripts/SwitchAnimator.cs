using UnityEngine;

public class SwitchAnimator : MonoBehaviour
{
    private PreFlightStep step;
    public GameObject nextPanel;

    void Awake()
    {
        step = GetComponent<PreFlightStep>();
    }

    public void OnSwitchComplete()
    {
        nextPanel?.SetActive(true);
        step?.CompleteStep();
    }
}
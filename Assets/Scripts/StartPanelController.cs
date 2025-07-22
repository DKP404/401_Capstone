using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartPanelController : MonoBehaviour
{
    public GameObject panel;
    public Animator switchAnimator;
    public PreFlightChecklist checklist;
    public string checklistFieldToToggle = "beaconLightOn";

    public void OnStartButtonClicked()
    {
        panel.SetActive(false); // Hide panel
        if (switchAnimator)
        {
            switchAnimator.SetTrigger("PlayButton"); // Play switch animation
        }

        // Toggle one checklist field (e.g. beacon light)
        var field = checklist.GetType().GetField(checklistFieldToToggle);
        if (field != null)
        {
            bool current = (bool)field.GetValue(checklist);
            field.SetValue(checklist, !current);
        }
    }
}
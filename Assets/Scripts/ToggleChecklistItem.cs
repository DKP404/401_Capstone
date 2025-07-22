using UnityEngine;
public class ToggleChecklistItem : MonoBehaviour
{
    public PreFlightChecklist checklist;
    public string fieldToToggle;

    public void Toggle()
    {
        var field = checklist.GetType().GetField(fieldToToggle);
        if (field != null)
        {
            bool current = (bool)field.GetValue(checklist);
            field.SetValue(checklist, !current);
        }
    }
}
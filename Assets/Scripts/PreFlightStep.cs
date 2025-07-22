using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFlightStep : MonoBehaviour
{
    public PreFlightManager manager;
    public string checkName;

    public void CompleteStep()
    {
        manager.MarkStepComplete(checkName);
    }
}
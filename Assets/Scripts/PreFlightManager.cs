using System.Collections.Generic;
using UnityEngine;

public class PreFlightManager : MonoBehaviour
{
    public List<string> requiredSteps;
    private HashSet<string> completedSteps = new HashSet<string>();

    public AudioClip beaconClip;
    public AudioClip enginesClip;
    public AudioClip batteryClip;
    // Add more clips as needed

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void MarkStepComplete(string stepName)
    {
        if (!completedSteps.Contains(stepName) && requiredSteps.Contains(stepName))
        {
            completedSteps.Add(stepName);
            Debug.Log($"Step completed: {stepName}");
            PlayCheckAudio(stepName);
        }

        if (completedSteps.Count == requiredSteps.Count)
        {
            Debug.Log("✅ All pre-flight checks completed! Plane can move.");
        }
    }

    private void PlayCheckAudio(string stepName)
    {
        AudioClip clip = stepName switch
        {
            "Beacon" => beaconClip,
            "Engines" => enginesClip,
            "Battery" => batteryClip,
            _ => null
        };

        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
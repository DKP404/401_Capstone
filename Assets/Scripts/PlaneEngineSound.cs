using UnityEngine;

public class PlaneEngineSound : MonoBehaviour
{
    public HingeJoint throttleHinge;
    public AudioSource engineAudio;
    public float minPitch = 0.8f;
    public float maxPitch = 2.0f;

    void Update()
    {
        if (throttleHinge && engineAudio)
        {
            float angle = throttleHinge.angle;
            float throttlePercent = Mathf.InverseLerp(-10, 10, angle); // Adjust to -10/10 if needed
            float pitch = Mathf.Lerp(minPitch, maxPitch, throttlePercent);
            engineAudio.pitch = pitch;
        }
    }
}
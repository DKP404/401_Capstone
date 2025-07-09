using UnityEngine;

public class PlaneEngineSound : MonoBehaviour
{
    public AudioSource engineAudio;

    void Start()
    {
        if (engineAudio != null)
        {
            engineAudio.Play();
        }
    }
}
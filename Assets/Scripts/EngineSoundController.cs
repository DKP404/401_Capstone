using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Rigidbody))]
public class EngineSoundController : MonoBehaviour
{
    public float maxSpeed = 30f;
    public float minVolume = 0.2f;
    public float maxVolume = 1f;

    private AudioSource engineAudio;
    private Rigidbody rb;

    void Start()
    {
        engineAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        engineAudio.loop = true;
        engineAudio.playOnAwake = true;
        engineAudio.Play();
    }

    void Update()
    {
        float speed = rb.velocity.magnitude;
        float normalizedSpeed = Mathf.Clamp01(speed / maxSpeed);
        engineAudio.volume = Mathf.Lerp(minVolume, maxVolume, normalizedSpeed);
    }
}
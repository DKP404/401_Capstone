using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip soundToPlay;

    private AudioSource audioSource;

    void Start()
    {
        if (Camera.main != null)
        {
            audioSource = Camera.main.GetComponent<AudioSource>();
            if (audioSource == null)
                audioSource = Camera.main.gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySound()
    {
        if (soundToPlay != null && audioSource != null)
            audioSource.PlayOneShot(soundToPlay);
    }
}
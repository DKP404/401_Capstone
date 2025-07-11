using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    public Animator animator;

    public void ToggleButton()
    {
        animator.Play("SwitchA_Toggle", 0, 0f);  // Plays from beginning every time
    }
}
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickForwarder : MonoBehaviour
{
    public Button sourceButton;
    public Button targetButton;

    void Start()
    {
        sourceButton.onClick.AddListener(() => targetButton.onClick.Invoke());
    }
}
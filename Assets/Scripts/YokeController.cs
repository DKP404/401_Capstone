using UnityEngine;
using UnityEngine.InputSystem;

public class YokeFlightControl : MonoBehaviour
{
    public InputActionReference leftStickInput; // Assign: XRI LeftHand Locomotion/Move
    public Rigidbody airplaneRb;
    public float rollSpeed = 30f;

    void FixedUpdate()
    {
        if (leftStickInput == null || airplaneRb == null) return;

        Vector2 input = leftStickInput.action.ReadValue<Vector2>();
        float rollInput = input.x; // Left/right on joystick

        // Apply roll (around Z axis for aircraft in Unity)
        Quaternion rollRotation = Quaternion.Euler(0f, 0f, -rollInput * rollSpeed * Time.fixedDeltaTime);
        airplaneRb.MoveRotation(airplaneRb.rotation * rollRotation);
    }
}
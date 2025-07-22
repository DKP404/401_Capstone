using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickThrustController : MonoBehaviour
{
    public InputActionReference moveAction; // Assign: XRI RightHand Locomotion/Move
    public float maxSpeed = 25f;
    public float takeoffSpeed = 15f;
    public float verticalLiftSpeed = 3f;
    public float accelerationTime = 3f; // Time in seconds to reach target speed

    private float currentSpeed = 0f;
    private float targetSpeed = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (moveAction != null)
            moveAction.action.Enable();
    }

    void FixedUpdate()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        float inputY = Mathf.Clamp(input.y, 0f, 1f); // only forward thrust
        targetSpeed = maxSpeed * inputY;

        // Smoothly approach target speed
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.fixedDeltaTime / accelerationTime);

        Vector3 forwardMovement = transform.forward * currentSpeed * Time.fixedDeltaTime;
        Vector3 upwardLift = currentSpeed >= takeoffSpeed ? transform.up * verticalLiftSpeed * Time.fixedDeltaTime : Vector3.zero;

        rb.MovePosition(rb.position + forwardMovement + upwardLift);
    }
}
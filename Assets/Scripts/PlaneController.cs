using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlaneController : MonoBehaviour
{
    public AudioSource engineAudio;
    public float minPitch = 0.5f;
    public float maxPitch = 2f;

    public float yawSpeed = 50f;
    public float rollSpeed = 80f;
    public float maxSpeed = 200f;
    public float acceleration = 10f;
    public float deceleration = 60f;
    public float takeoffSpeed = 20f; // km/h or consistent unit
    public float liftForce = 50000f;
    public float landingForce = 30000f;
    public float currentSpeed = 0f;

    private Rigidbody rb;
    private FlightLockManager flightLock;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        flightLock = FindObjectOfType<FlightLockManager>();

        if (engineAudio == null)
            engineAudio = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {
        if (flightLock == null || !flightLock.canFly)
            return;

        // Adjust speed based on input
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentSpeed -= deceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

            // Auto-land if in air and slowing down
            if (!IsGrounded())
            {
                rb.AddForce(-transform.up * landingForce * Time.fixedDeltaTime);
            }
        }

        // Stop moving if speed is very low
        if (currentSpeed <= 0.1f)
        {
            currentSpeed = 0f;
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.5f);
        }

        // Apply forward movement only if speed > 0
        if (currentSpeed > 0)
        {
            rb.AddForce(transform.forward * currentSpeed);
        }

        // Auto-lift when reaching takeoff speed and still grounded
        if (currentSpeed >= takeoffSpeed && IsGrounded())
        {
            rb.AddForce(transform.up * liftForce);
        }

        // Apply rotation only if keys are pressed
        float yaw = 0f;
        if (Input.GetKey(KeyCode.A)) yaw = -1f;
        else if (Input.GetKey(KeyCode.D)) yaw = 1f;

        float roll = 0f;
        if (Input.GetKey(KeyCode.Q)) roll = 1f;
        else if (Input.GetKey(KeyCode.E)) roll = -1f;

        // Stop existing rotation to prevent unwanted spin
        rb.angularVelocity = Vector3.zero;

        Vector3 torque = new Vector3(
            0f,
            yaw * yawSpeed,
            roll * rollSpeed
        );

        rb.AddRelativeTorque(torque * Time.fixedDeltaTime);

        if (engineAudio != null)
        {
            float speedPercent = currentSpeed / maxSpeed;
            engineAudio.pitch = Mathf.Lerp(minPitch, maxPitch, speedPercent);
            engineAudio.volume = Mathf.Clamp(speedPercent, 0.1f, 1f);
        }
    }

    // Helper method to check if grounded
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -transform.up, 2f);
    }
}
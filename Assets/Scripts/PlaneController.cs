using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlaneController : MonoBehaviour
{
    public float thrust = 2000f;
    public float pitchSpeed = 50f;
    public float yawSpeed = 50f;
    public float rollSpeed = 80f;

    private Rigidbody rb;
    private FlightLockManager flightLock;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        flightLock = FindObjectOfType<FlightLockManager>();
    }

    void FixedUpdate()
    {
        if (flightLock == null || !flightLock.canFly)
            return;

        // Thrust forward
        rb.AddForce(transform.forward * thrust * Time.fixedDeltaTime);

        // Control inputs
        float pitch = Input.GetAxis("Vertical");    // W/S keys
        float yaw = Input.GetAxis("Horizontal");    // A/D keys
        float roll = 0f;

        if (Input.GetKey(KeyCode.Q)) roll = 1f;
        else if (Input.GetKey(KeyCode.E)) roll = -1f;

        Vector3 torque = new Vector3(
            pitch * pitchSpeed,
            yaw * yawSpeed,
            roll * rollSpeed
        );

        rb.AddRelativeTorque(torque * Time.fixedDeltaTime);
    }
}
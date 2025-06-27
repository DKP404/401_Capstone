using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float thrust = 2000f;
    public float rotationSpeed = 50f;
    public float liftPower = 500f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Throttle - Forward
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(transform.forward * thrust * Time.deltaTime);

        // Yaw Left/Right
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        // Pitch Up/Down
        if (Input.GetKey(KeyCode.S))
            transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);

        // Roll Left/Right
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);

        // Lift when moving forward
        if (rb.velocity.magnitude > 10f)
            rb.AddForce(Vector3.up * liftPower * Time.deltaTime);
    }
}
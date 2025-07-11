using UnityEngine;

public class ThrottleController : MonoBehaviour
{
    public HingeJoint throttleHinge;
    public Rigidbody airplaneRb;
    public Transform thrustDirection;
    public float maxThrustForce = 8000f;
    public float thrustSmoothSpeed = 2f;

    private float currentThrust = 0f;

    void FixedUpdate()
    {
        if (throttleHinge && airplaneRb)
        {
            float angle = throttleHinge.angle;
            float throttlePercent = Mathf.InverseLerp(0, -10, angle); // adjust range for your hinge
            if (throttlePercent < 0.05f) throttlePercent = 0f;
            throttlePercent = Mathf.Clamp01(throttlePercent);

            float targetThrust = throttlePercent * maxThrustForce;
            currentThrust = Mathf.Lerp(currentThrust, targetThrust, Time.fixedDeltaTime * thrustSmoothSpeed);

            airplaneRb.AddForce(thrustDirection.forward * currentThrust);
        }
    }
}
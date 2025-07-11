using UnityEngine;

public class YokeController : MonoBehaviour
{
    public Transform yokeTransform;           // Assign the yoke GameObject
    public Rigidbody airplaneRigidbody;       // Assign the airplane Rigidbody
    public float pitchForce = 5f;
    public float rollForce = 5f;

    void FixedUpdate()
    {
        if (yokeTransform && airplaneRigidbody)
        {
            float pitchAngle = yokeTransform.localEulerAngles.x;
            float rollAngle = yokeTransform.localEulerAngles.z;

            // Convert Unity's 0-360 to -180 to 180
            if (pitchAngle > 180) pitchAngle -= 360;
            if (rollAngle > 180) rollAngle -= 360;

            // Apply torque
            airplaneRigidbody.AddTorque(-transform.right * pitchAngle * pitchForce);
            airplaneRigidbody.AddTorque(-transform.forward * rollAngle * rollForce);
        }
    }
}
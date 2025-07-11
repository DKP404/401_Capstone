using UnityEngine;

public class FollowSeat : MonoBehaviour
{
    public Transform seatAnchor;

    void LateUpdate()
    {
        transform.position = seatAnchor.position;
        transform.rotation = seatAnchor.rotation;
    }
}
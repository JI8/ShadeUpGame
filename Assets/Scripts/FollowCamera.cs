
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = NewMethod();
        Vector3 smoothedPostion = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPostion;

    }

    private Vector3 NewMethod()
    {
        return target.position + offset;
    }
}

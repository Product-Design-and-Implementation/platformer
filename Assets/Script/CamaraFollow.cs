using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;

    private Vector3 velocity = Vector3.zero;

    public Transform target;

    void LateUpdate()
    {
        // Keep the original z-value of the camera
        float originalZ = transform.position.z;

        Vector3 newPos = new Vector3(target.position.x, target.position.y, originalZ);
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, newPos, ref velocity, FollowSpeed);
        transform.position = smoothPos;
    }
}

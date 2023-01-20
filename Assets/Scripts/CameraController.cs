using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The player to follow
    public float smoothSpeed = 0.125f; // The speed of camera movement
    public Vector3 offset; // The offset of the camera from the player
    public LayerMask wallMask; // The layer mask for the walls

    void FixedUpdate()
    {
        // Get the desired position of the camera
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Check if the camera hit a wall
        if (Physics2D.Linecast(target.position, smoothedPosition, wallMask))
        {
            // Stop following the player if the camera hit a wall
            transform.position = smoothedPosition;
        }
        else
        {
            // Keep following the player if no wall is hit
            transform.position = smoothedPosition;
        }
    }
}
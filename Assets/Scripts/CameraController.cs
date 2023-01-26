using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The player to follow
    public float smoothSpeed = 0.125f; // The speed of camera movement
    public Vector3 offset; // The offset of the camera from the player

    public Vector3 originalPos;

    private void Awake()
    {
        originalPos = this.transform.position;
    }

    void FixedUpdate()
    {
        // Get the desired position of the camera
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            this.transform.position = originalPos;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PropManager Class definition
public class PropManager : MonoBehaviour
{
    // Reference to Rigidbody2D component
    Rigidbody2D rb;
    // Variable to store starting rotation of the object
    Quaternion startingRot;

    // Awake function is called before Start function
    private void Awake()
    {
        // Get reference to Rigidbody2D component on this object
        rb = GetComponent<Rigidbody2D>();
        // Store the starting rotation of the object
        startingRot = transform.rotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Remove constraints on the object
            rb.constraints = RigidbodyConstraints2D.None;
        }

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Roof"))
        {
            // Constrain rotation of the object
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            // Constrain position along the Y axis
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    private void Update()
    {
        // Reset the rotation of the object to its starting rotation
        transform.rotation = startingRot;
    }
}

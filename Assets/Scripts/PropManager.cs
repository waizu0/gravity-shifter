using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
    Rigidbody2D rb; // Reference to Rigidbody2D component
    Quaternion startingRot; // Store starting rotation of the object
    GameObject Player; // Reference to player GameObject
    BoxCollider2D col; // BoxCollider2D component
    bool collidingWithPlayer; // Flag for collision with player
    public bool onAir = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Get reference to Rigidbody2D component
        startingRot = transform.rotation; // Store the starting rotation of the object
        Player = GameObject.Find("Player"); // Find the player GameObject
        col = GetComponent<BoxCollider2D>(); // Get reference to the BoxCollider2D component
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (this.gameObject.tag == "Prop")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                rb.constraints = RigidbodyConstraints2D.None; // Remove constraints on the object
                collidingWithPlayer = true; // Set flag for collision with player
            }

            if (collision.gameObject.CompareTag("Ground") && !collidingWithPlayer  || collision.gameObject.CompareTag("Roof") && !collidingWithPlayer)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Constrain rotation of the object
                rb.constraints = RigidbodyConstraints2D.FreezePositionY; // Constrain position along the Y axis
                onAir = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collidingWithPlayer = false; // Set flag for no collision with player
        }

        if(collision.gameObject.tag != "Ground" || collision.gameObject.tag != "Roof")
        {
            onAir = true;
        }
    }

    private void Update()
    {
        transform.rotation = startingRot; // Reset the rotation of the object to its starting rotation

        if (onAir)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}

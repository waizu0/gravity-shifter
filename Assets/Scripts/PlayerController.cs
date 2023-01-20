using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables for player movement 
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float doubleJumpForce = 2.5f;

    // Variables for player health
    public float health = 100f;
    public bool canDoubleJump = false;

    // Reference to player's Rigidbody2D component
    private Rigidbody2D rb;
    private bool isJumping = false;

    void Start()
    {
        // Get the reference of the player's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal input and set player's velocity
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Check if the jump button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            // Check if the player is on the ground
            if (!isJumping)
            {
                // Add jump force to the player's Rigidbody2D
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
            }
            // Check if the player can perform double jump
            else if (canDoubleJump)
            {
                // Add double jump force to the player's Rigidbody2D
                rb.AddForce(new Vector2(0f, doubleJumpForce), ForceMode2D.Impulse);
                canDoubleJump = false;
            }
        }
    }

    // Check for collision with the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is colliding with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            canDoubleJump = true;
        }
    }

    // Function for taking damage
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Function for player death
    private void Die()
    {
        //Blah Blah Blah
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables for player movement 
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float doubleJumpForce = 2.5f;
    public float health = 100f;
    public bool canDoubleJump = false;

    private Rigidbody2D rb;
    public bool isJumping = false;
    private bool isOnRoof = false;

    public float gravityChangeSpeed = 1f; //Speed to change the gravity
    public Animator _camAnimator; //Animator of camera gameobj
    public Animator playerAnimator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector2(0f, -9.8f * gravityChangeSpeed);
        isOnRoof = true;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        playerAnimator.SetBool("Jumping", isJumping);

        if(moveX != 0)
        {
            playerAnimator.SetBool("Walking", true);
        }
        else
        {
            playerAnimator.SetBool("Walking", false);
        }


        // Check if the jump button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
            }
            else if (canDoubleJump)
            {
                rb.AddForce(new Vector2(0f, doubleJumpForce), ForceMode2D.Impulse);
                canDoubleJump = false;
            }
        }

        // Check if the "Z" button is pressed
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isOnRoof)
            {
                // Change gravity and switch to roof
                Physics2D.gravity = new Vector2(0f, -9.8f * gravityChangeSpeed);
                isOnRoof = true;
                _camAnimator.Play("ShiftFloor", -1, 0f);
            }
            else
            {
                // Change gravity and switch to ground
                Physics2D.gravity = new Vector2(0f, 9.8f * gravityChangeSpeed);
                isOnRoof = false;
                _camAnimator.Play("ShiftRoof", -1, 0f);
            }
        }




        if(Input.GetKeyDown(KeyCode.A))
        {
            this.transform.localScale = new Vector3(-1f, this.transform.localScale.y, this.transform.localScale.z);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.localScale = new Vector3(1f, this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isOnRoof)
        {
            isJumping = false;
            canDoubleJump = true;
        }
        else if (collision.gameObject.CompareTag("Roof") && isOnRoof)
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
        // Code for death
    }
    }
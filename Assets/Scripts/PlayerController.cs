using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float doubleJumpForce = 2.5f;
    public float health = 100f;
    public bool canDoubleJump = false;

    private Rigidbody2D rb;
    private bool isJumping = false;
    public bool isOnRoof = false;

    public float _gravityChangeSpeed = 6f;
    public Animator _camAnimator;
    Animator thisAnim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector2(0f, -9.8f * _gravityChangeSpeed);
        isOnRoof = false;
        thisAnim = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        thisAnim.SetBool("Jumping", isJumping);

        if (isOnRoof)
        {
            moveX = moveX * -1;
        }
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Check if the jump button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                if (isOnRoof)
                {
                    rb.AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                }
                isJumping = true;
            }
            else if (canDoubleJump)
            {
                if (isOnRoof)
                {
                    rb.AddForce(new Vector2(0f, -doubleJumpForce), ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(new Vector2(0f, doubleJumpForce), ForceMode2D.Impulse);
                }
                canDoubleJump = false;
            }
        }

        // Check if the "Z" button is pressed
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isOnRoof)
            {
                // Change gravity and switch to roof
                Physics2D.gravity = new Vector2(0f, 9.8f * _gravityChangeSpeed);
                transform.Rotate(180f, 0f, 0f);
                isOnRoof = true;
                _camAnimator.Play("ShiftRoof", -1, 0f);
            }
            else
            {
                // Change gravity and switch to ground
                Physics2D.gravity = new Vector2(0f, -9.8f * _gravityChangeSpeed);
                transform.Rotate(180f, 0f, 0f);
                isOnRoof = false;
                _camAnimator.Play("ShiftFloor", -1, 0f);

            }
        }

        if(Input.GetKeyDown(KeyCode.A) && !isOnRoof)
        {
            this.transform.localScale = new Vector3(-1, this.transform.localScale.y, this.transform.localScale.z);
        }
        if (Input.GetKeyDown(KeyCode.D) && !isOnRoof)
        {
            this.transform.localScale = new Vector3(1, this.transform.localScale.y, this.transform.localScale.z);
        }

        if (Input.GetKeyDown(KeyCode.A) && isOnRoof)
        {
            this.transform.localScale = new Vector3(1, this.transform.localScale.y, this.transform.localScale.z);
        }
        if (Input.GetKeyDown(KeyCode.D) && isOnRoof)
        {
            this.transform.localScale = new Vector3(-1, this.transform.localScale.y, this.transform.localScale.z);
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

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Code for death
    }
}
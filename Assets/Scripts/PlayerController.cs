using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private bool isJumping = false;
    public bool isOnRoof = false;

    public float _gravityChangeSpeed = 6f;
    public Animator _camAnimator;
    Animator thisAnim;
    private float oldPos;
    public Camera cam;
    public GameObject blood;
    public ParticleSystem dust;
    bool _isPlayingDust;
    public bool isMoving;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector2(0f, -9.8f * _gravityChangeSpeed);
        isOnRoof = false;
        thisAnim = GetComponent<Animator>();
        oldPos = transform.position.x;

    }

    void Update()
    {
        isMoving = Mathf.Abs(rb.velocity.x) > 0.1f;

        Vector3 screenPos = cam.WorldToScreenPoint(transform.position);
        if (Input.mousePosition.x < screenPos.x)
        {
            this.transform.localScale = new Vector3(-1, this.transform.localScale.y, this.transform.localScale.z);
        }
        else
        {
            this.transform.localScale = new Vector3(1, this.transform.localScale.y, this.transform.localScale.z);
        }

        if (isMoving)
        {
            if (!_isPlayingDust)
            {
                dust.Play();
                _isPlayingDust = true;
            }
        }
        else if (_isPlayingDust)
        {
            dust.Stop();
            _isPlayingDust = false;
        }


        oldPos = transform.position.x;

        float moveX = Input.GetAxis("Horizontal");

        thisAnim.SetBool("Jumping", isJumping);
        bool isWalking = Mathf.Abs(moveX) > 0.1f && Mathf.Abs(rb.velocity.x) > 0.1f;
        thisAnim.SetBool("Walking", isWalking);



        //if (isOnRoof)
        //{
        //    moveX = moveX * -1;
        //}
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Check if the jump button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                dust.Play();
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

        if (Input.GetKeyDown(KeyCode.A) && !isOnRoof)
        {
            this.transform.localScale = new Vector3(-1, this.transform.localScale.y, this.transform.localScale.z);
        }
        if (Input.GetKeyDown(KeyCode.D) && !isOnRoof)
        {
            this.transform.localScale = new Vector3(1, this.transform.localScale.y, this.transform.localScale.z);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isOnRoof)
        {
            isJumping = false;
        }
        else if (collision.gameObject.CompareTag("Roof") && isOnRoof)
        {
            isJumping = false;
        }
        if (collision.gameObject.tag == "Roof" && Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("Prop")))
        {
            Die();
        }
    }

    public void Die()
    {
        this.gameObject.SetActive(false);

        GameObject bloodInstance = Instantiate(blood, transform.position, Quaternion.identity);

    }
}
    

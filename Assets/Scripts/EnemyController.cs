using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float damage = 20f;
    public float speed = 5f;
    public GameObject bloodParticle;
    private bool facingRight = true;
    private Rigidbody2D rb;
    private PlayerController player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (facingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Prop")
        {
            facingRight = !facingRight;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            player.Die();
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        if (collision.gameObject.CompareTag("Laser"))
        {
           
            Death();
            
        }
    }

    private void Death()
    {
        Instantiate(bloodParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
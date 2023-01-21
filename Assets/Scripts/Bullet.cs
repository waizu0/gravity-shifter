using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // The speed of the bullet
    private Transform player;
    float playerXLocal;
    public float lifeTime = 1f;
    float defaultSpeed;

    private void Awake()
    {
        defaultSpeed = speed;
    }

    // OnEnable is called when the object is enabled
    void OnEnable()
    {
        // Find the player object and store its transform
        player = GameObject.Find("Player").transform;
        // Store the player's local scale x value
        playerXLocal = player.transform.localScale.x;
        // Invoke the disableMe function after the specified lifetime
        Invoke("disableMe", lifeTime);
        speed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is facing left
        if (playerXLocal == -1f)
        {
            // Move the bullet to the left
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        // Check if the player is facing right
        if (playerXLocal == 1)
        {
            // Move the bullet to the right
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
    }

    // Function to disable the game object
    public void disableMe()
    {
        this.gameObject.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            // Inverta a direção X da bala
            speed = -speed;
            // Aplique a nova direção X como força
            GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
        }

        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerController>().TakeDamage(10f);
        }
    }
}


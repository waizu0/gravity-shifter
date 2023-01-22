using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // The speed of the bullet
    private Transform player;
    float playerXLocal;
    public float lifeTime = 1f;

    // OnEnable is called when the object is enabled
    void OnEnable()
    {
        lifeTime = 2.5f;
        // Find the player object and store its transform
        player = GameObject.Find("Player").transform;
        // Store the player's local scale x value
        playerXLocal = player.transform.localScale.x;
        // Invoke the disableMe function after the specified lifetime
        Invoke("disableMe", lifeTime);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        disableMe();
    }
}


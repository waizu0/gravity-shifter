using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // The speed of the bullet
    private static Transform player;
    private float playerXLocal;
    public int damage;
    public Camera cam;
    Renderer renderer;
    public ParticleSystem sparkle;

    private void Awake()
    {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        renderer = GetComponent<Renderer>();
    }

    // OnEnable is called when the object is enabled
    void OnEnable()
    {

        // Check if player is already stored
        if (player == null)
        {
            player = GameObject.FindObjectOfType<PlayerController>().transform;
        }
        // Store the player's local scale x value
        playerXLocal = player.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is facing left
        if (playerXLocal == -1f)
        {
            // Move the bullet to the left
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }
        // Check if the player is facing right
        else if (playerXLocal == 1)
        {
            // Move the bullet to the right
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }

        if (!renderer.isVisible)
            this.gameObject.SetActive(false);
    }

    // Function to disable the game object
    public void disableMe()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            PlaySparkle();
        }
    }

    public void PlaySparkle()
    {
        disableMe();
    }
}
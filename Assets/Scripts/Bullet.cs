using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private static Transform player;
    private float playerXLocal;
    int damage;
    public Camera cam;
    Renderer renderer;
    public ParticleSystem sparkle;


    private void Awake()
    {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        renderer = GetComponent<Renderer>();

     
    }

    void OnEnable()
    {

        if (player == null)
        {
            player = GameObject.FindObjectOfType<PlayerController>().transform;
        }
        playerXLocal = player.transform.localScale.x;
    }

    void Update()
    {
        if (playerXLocal == -1f) {

         transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }
        else if (playerXLocal == 1)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }

        if (!renderer.isVisible)
            this.gameObject.SetActive(false);
    }

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
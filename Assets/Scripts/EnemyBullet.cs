using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    Renderer _renderer;
    PlayerController player;


    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
     
    }
    void Update()
    {       
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
            if (!_renderer.isVisible)
            this.gameObject.SetActive(false);
    }

    public void disableMe()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.Die();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Transform player;
    float playerXLocal;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        playerXLocal = player.transform.localScale.x;
        Invoke("disableMe", 1.0f);
    }

    void Update()
    {
        if(playerXLocal == -1f)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if(playerXLocal == 1)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
    }

    public void disableMe()
    {
        this.gameObject.SetActive(false);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayerChanger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer render;

        if(collision.gameObject.tag == "Player")
        {
            render = collision.gameObject.GetComponent<SpriteRenderer>();
            render.sortingOrder = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SpriteRenderer render;

        if (collision.gameObject.tag == "Player")
        {
            render = collision.gameObject.GetComponent<SpriteRenderer>();
            render.sortingOrder = 4;
        }
    }
}

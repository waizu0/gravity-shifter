using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
    Rigidbody2D rb;
    Quaternion startingRot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startingRot = transform.rotation;

        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Roof"))
        {
            Debug.Log("SSSSSSJNJKNJSNA");
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    private void Update()
    {
        transform.rotation = startingRot;
    }
}

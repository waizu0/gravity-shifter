using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCol : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("colidiu");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colidiu");

    }
}

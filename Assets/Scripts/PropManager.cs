using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PropManager Class definition
public class PropManager : MonoBehaviour
{
    // Reference to Rigidbody2D component
    Rigidbody2D rb;
    // Variable to store starting rotation of the object
    Quaternion startingRot;

    public bool _isPC; //If is a PC, then the collision should be enabled only when the player is > it in Y position
    GameObject Player;
    public bool _onPcArea;

    // Awake function is called before Start function
    private void Awake()
    {
        // Get reference to Rigidbody2D component on this object
        rb = GetComponent<Rigidbody2D>();
        // Store the starting rotation of the object
        startingRot = transform.rotation;
        Player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Remove constraints on the object
            rb.constraints = RigidbodyConstraints2D.None;

            if(_isPC)
            {
                _onPcArea = true;
            }
        }

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Roof"))
        {
            // Constrain rotation of the object
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            // Constrain position along the Y axis
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (_isPC)
            {
                _onPcArea = false;
                
            }
        }
    }

    private void Update()
    {
        if (_onPcArea) { Debug.Log("On PC AREA"); }
        if(!_onPcArea) { Debug.Log("Not on PC area"); }
        // Reset the rotation of the object to its starting rotation
        transform.rotation = startingRot;

        if(_isPC)
        {
            if(Player.transform.position.y > this.gameObject.transform.position.y && !_onPcArea)
            {
                this.GetComponent<BoxCollider2D>().isTrigger = true;
                this.GetComponent<Rigidbody2D>().simulated = true;
            }
            else if(Player.transform.position.y <= this.gameObject.transform.position.y)
            {
                this.GetComponent<BoxCollider2D>().isTrigger = false;
                this.GetComponent<Rigidbody2D>().simulated = false;
            }
        }
      
    }
}

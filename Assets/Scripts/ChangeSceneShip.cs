using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneShip : MonoBehaviour
{

    public GameObject transition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transition.gameObject.SetActive(true);
            collision.gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }
}

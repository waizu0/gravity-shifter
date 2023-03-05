using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberAnimation : MonoBehaviour
{
    Animator _anim;
    public GameObject player;
    private MainGameController _MGC; // Reference to the Main Game Controller script component
    public GameObject transition;


    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _MGC = GameObject.Find("GameController").GetComponent<MainGameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player.GetComponent<PlayerController>().isOnRoof == false)
            {
                player.SetActive(false);
                _anim.Play("ChamberOn", -1, 0f);
            }
        }
    }

    public void DisablePlayer()
    {
        _MGC.FinishLevel(); // Call the FinishLevel function in the MainGameController script

    }

    public void Transition()
    {
        transition.SetActive(true);
    }

}

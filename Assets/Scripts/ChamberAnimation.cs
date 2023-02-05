using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberAnimation : MonoBehaviour
{
    Animator _anim;
    public GameObject player;
    private MainGameController _MGC; // Reference to the Main Game Controller script component


    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _MGC = GameObject.Find("GameController").GetComponent<MainGameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _anim.Play("ChamberOn", -1, 0f);
        player.GetComponent<PlayerController>().moveSpeed = 0;
    }

    public void DisablePlayer()
    {
        player.SetActive(false);
        _MGC.FinishLevel(); // Call the FinishLevel function in the MainGameController script

    }

}

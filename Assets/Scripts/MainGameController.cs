using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour
{
   public int _levelTime;
   public GameObject _transitionOverlay;
   public GameObject pause;
    PlayerController player;
    GunController gun;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        gun = GameObject.Find("Player").GetComponent<GunController>();
    }

    public void FinishLevel()
    {
        _transitionOverlay.SetActive(true);
        Time.timeScale = 0;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause.activeSelf)
            {
                pause.SetActive(false);
                player.enabled = true;
                gun.enabled = true;
                Time.timeScale = 1;
            }
            else
            {
                pause.SetActive(true);
                player.enabled = false;
                gun.enabled = false;
                Time.timeScale = 0;
            }
        }
    }
}

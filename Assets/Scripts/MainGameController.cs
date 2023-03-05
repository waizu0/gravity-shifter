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
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pause.SetActive(true);
        gun.enabled = false;
        player.canInteract = false;
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        pause.SetActive(false);
        gun.enabled = true;
        player.canInteract = true;
        Time.timeScale = 1;
    }
}

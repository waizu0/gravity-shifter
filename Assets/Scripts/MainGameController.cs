using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour
{
   public int _levelTime;
   public GameObject _transitionOverlay;

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
    }
}

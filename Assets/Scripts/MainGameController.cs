using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour
{
   public int _levelTime;
   public GameObject _transitionOverlay;

    public void FinishLevel()
    {
        _transitionOverlay.SetActive(true);
        Time.timeScale = 0;
    }
}

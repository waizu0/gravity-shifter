using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{

    public MainGameController player;

    public void Continue()
    {
        player.Unpause();
    }

    public void Quit()
    {
        Application.Quit();
    }
}

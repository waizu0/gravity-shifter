using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string _startGameScene;
    public void StartGame()
    {
        SceneManager.LoadScene(_startGameScene);
        Time.timeScale = 0;
    }
}

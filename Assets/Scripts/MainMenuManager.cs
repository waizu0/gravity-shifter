using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject startArea, menuArea, optionsArea;
    public TextMeshProUGUI _pressAnyButtonText;
    public string _startGameScene;

    private void Start()
    {
        // Start the coroutine to blink the text
        StartCoroutine("BlinkText");
    }

    // Coroutine to blink the text every 0.7 seconds
    private IEnumerator BlinkText()
    {
        while (true)
        {
            _pressAnyButtonText.enabled = !_pressAnyButtonText.enabled;
            yield return new WaitForSeconds(0.7f);
        }
    }

    private void Update()
    {
        if (Input.anyKeyDown && startArea.activeSelf == true)
        {
            startArea.SetActive(false); //Deactivates 'Press Any Button' area
            menuArea.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit(); //Quits the game lol
    }

 
}

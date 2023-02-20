using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject startArea, menuArea, optionsArea;
    public TextMeshProUGUI _pressAnyButtonText;
    public string _startGameScene;

    public AudioMixer audioMixer;
    public Toggle fullscreenToggle;
    public Slider volumeSlider;

    private void Start()
    {
        // Start the coroutine to blink the text
        StartCoroutine("BlinkText");
        if (Screen.fullScreen)
        {
            fullscreenToggle.isOn = true;
        }
        else
        {
            fullscreenToggle.isOn = false;
        }
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

    // Toggle fullscreen mode
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        fullscreenToggle.isOn = isFullscreen; // Update the toggle's state to match the current fullscreen mode
    }

    // Set the volume level using a slider
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume); // Convert the slider value to a logarithmic scale suitable for the AudioMixer
    }
}

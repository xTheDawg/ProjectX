using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    private StorageService storageService = StorageService.GetInstance();

    private Text storageInfoText;
    private Text animationSpeedLabel;
    private Slider animationSpeedSlider;

    // Pause menu
    private Text pausedInfoText;
    private Button resumeButton;
    private Button exitButton;

    private bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        // Ingame info
        storageInfoText = GameObject.Find("StorageInfoText").GetComponent<Text>();
        animationSpeedLabel = GameObject.Find("AnimationSpeedLabel").GetComponent<Text>();
        animationSpeedSlider = GameObject.Find("AnimationSpeedSlider").GetComponent<Slider>();

        // Pause menu
        pausedInfoText = GameObject.Find("PausedInfoText").GetComponent<Text>();
        pausedInfoText.enabled = false;
        
        resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        resumeButton.gameObject.SetActive(false);
        resumeButton.onClick.AddListener(TogglePauseMenu);
        
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        exitButton.gameObject.SetActive(false);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        // Set storage info text
        String tempText = "Storage Resources:\n";
        foreach (KeyValuePair<ResourceType, int> resource in storageService.resources)
        {
            tempText += resource.Key + ": " + resource.Value + "\n";
        }

        storageInfoText.text = tempText;

        // Handle Slider value
        float sliderValue = animationSpeedSlider.value;
        Globals.animationSpeed = sliderValue;
        Globals.actionCompleteDelay = Globals.dayNightSpeed = 1 / sliderValue;

        // Handle escape click
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    // Toggles visibility of pause menu
    private void TogglePauseMenu()
    {
        // Toggle game paused
        gamePaused = !gamePaused;

        // Pause game
        Time.timeScale = gamePaused ? 0f : 1f;
            
        // Hide/show ingame info (hidden when paused)
        storageInfoText.enabled = !gamePaused;
        animationSpeedLabel.enabled = !gamePaused;
        animationSpeedSlider.gameObject.SetActive(!gamePaused);
            
        // Show pause menu (shown when paused)
        pausedInfoText.enabled = gamePaused;
        resumeButton.gameObject.SetActive(gamePaused);
        exitButton.gameObject.SetActive(gamePaused);
    }

    // End game
    private void OnExitButtonClick()
    {
        Application.Quit();
    }


}
using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    // References to the main menu buttons
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button aboutButton;

    private void Awake()
    {
        // Show all main menu buttons when the scene starts
        MainMenu(true);
    }

    // Called when the Play button is clicked
    public void PlayButton()
    {
        // Open the loading screen through the SceneController
        SceneController.Instance.LoadGame();
    }

    // Called when the Settings button is clicked
    public void SettingsButton()
    {
        // Open the settings scene
        SceneController.Instance.OpenSettings();
    }

    // Called when the Exit button is clicked
    public void ExitButton()
    {
        // Close the game application
        SceneController.Instance.ExitGame();
    }

    // Called when the About button is clicked
    public void AboutButton()
    {
        // Open the about scene
        SceneController.Instance.OpenAbout();
    }

    // Show or hide all main menu buttons
    private void MainMenu(bool condition)
    {
        playButton.gameObject.SetActive(condition);
        settingsButton.gameObject.SetActive(condition);
        exitButton.gameObject.SetActive(condition);
        aboutButton.gameObject.SetActive(condition);
    }
}
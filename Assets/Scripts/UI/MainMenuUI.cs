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

    [SerializeField] private GameObject loadingScene;

    private void Awake()
    {
        // Show all main menu buttons when the scene starts
        MainMenu(true);

        loadingScene.gameObject.SetActive(false);
    }

    public void ContinueButton()
    {
        loadingScene.gameObject.SetActive(true);
    }
    public void NewGameButton()
    {

    }

    public void LoadGameButton()
    {

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
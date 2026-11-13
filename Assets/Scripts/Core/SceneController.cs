using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Singleton instance to access SceneController from other scripts
    public static SceneController Instance;

    private void Awake()
    {
        // Assign this object as the SceneController instance
        Instance = this;
    }

    // Load the main menu scene
    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    // Load the loading screen scene
    public void LoadGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    // Load the main gameplay scene
    public void GameplayScene()
    {
        SceneManager.LoadScene("GameplayScene01");
    }

    // Open the settings scene
    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    // Close the game application
    public void ExitGame()
    {
        Application.Quit();
    }

    // Open the about scene
    public void OpenAbout()
    {
        SceneManager.LoadScene("AboutScene");
    }
}
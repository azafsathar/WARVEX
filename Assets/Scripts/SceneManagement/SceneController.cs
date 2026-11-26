using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Singleton instance to access SceneController from other scripts
    public static SceneController Instance { get; private set; }
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

    // Load the main gameplay scene
    public void GameplayScene()
    {
        SceneManager.LoadScene("GameplayScene01");
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
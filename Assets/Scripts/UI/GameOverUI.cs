using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        GameOverMenu(false);
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDied += HandleGameOverMenu;
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerDied -= HandleGameOverMenu;
    }

    private void HandleGameOverMenu()
    {
        GameOverMenu(true);
    }
    private void GameOverMenu(bool condition)
    {
        gameOverPanel.gameObject.SetActive(condition);
        retryButton.gameObject.SetActive(condition);
        settingsButton.gameObject.SetActive(condition);
        mainMenuButton.gameObject.SetActive(condition);
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        SceneController.Instance.MainMenuScene();
    }

}

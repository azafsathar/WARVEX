using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    // Reference to the UI text that displays the player's score
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    // Reference to the UI image that displays the player's health bar
    [SerializeField] private Image healthBar;

    // Reference to the pause button
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] public GameObject MainMenuExitConfirmationUI;

    private bool isSpaceButtonPressed = false;


    private void OnEnable()
    {
        // Subscribe to the event when the player's health changes
        PlayerHealth.OnHealthChanged += UpdateHealth;

        // Subscribe to the event when the player's score changes
        ScoreManager.OnScoreChanged += UpdateScore;

        CoinSaveSystem.onHighScore += UpdateHighScore;
    }

    private void OnDisable()
    {
        // Unsubscribe from the health change event
        PlayerHealth.OnHealthChanged -= UpdateHealth;

        // Unsubscribe from the score change event
        ScoreManager.OnScoreChanged -= UpdateScore;

        CoinSaveSystem.onHighScore -= UpdateHighScore;
    }

    private void Awake()
    {
        pausePanel.gameObject.SetActive(false);
        MainMenuExitConfirmationUI.gameObject.SetActive(false);
    }


    // Update the health bar whenever the player's health changes
    private void UpdateHealth(float currentHealth)
    {
        // Convert the current health value into a fill amount between 0 and 1
        healthBar.fillAmount = currentHealth / 100f;
    }

    // Update the score text whenever the player's score changes
    private void UpdateScore(float score)
    {
        // Display the updated score on the UI
        scoreText.text = "Score: " + score;
    }

    private void UpdateHighScore(float score)
    {
        highScoreText.text = "High Score: " + score;
    }

    public void YestoMainMenu()
    {
        SceneController.Instance.MainMenuScene();
        Time.timeScale = 1f;
    }
    public void NotoMainMenu()
    {
        MainMenuExitConfirmationUI.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !isSpaceButtonPressed)
        {
            PauseButton();
            isSpaceButtonPressed = true;
        }
    }

    public void PauseButton()
    {
        AudioManager.Instance.PlayMenuBG();
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0f;

    }

    public void ResumeButton()
    {
        AudioManager.Instance.PlayMainBG();
        pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1f;

        isSpaceButtonPressed = false;
    }

    public void SaveButton()
    {
        CoinSaveSystem.Instance.SaveGame();
    }

    public void MissionButton()
    {

    }

    public void MainMenu()
    {
        pausePanel.gameObject.SetActive(false);
        MainMenuExitConfirmationUI.gameObject.SetActive(true);

    }
}
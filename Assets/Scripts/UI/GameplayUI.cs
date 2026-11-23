
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
     // Reference to the UI text that displays the player's score
    [SerializeField] private TextMeshProUGUI scoreText;

    // Reference to the UI image that displays the player's health bar
    [SerializeField] private Image healthBar;

    // Reference to the pause button
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;


    private void OnEnable()
    {
        // Subscribe to the event when the player's health changes
        PlayerHealth.OnHealthChanged += UpdateHealth;

        // Subscribe to the event when the player's score changes
        ScoreManager.OnScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        // Unsubscribe from the health change event
        PlayerHealth.OnHealthChanged -= UpdateHealth;

        // Unsubscribe from the score change event
        ScoreManager.OnScoreChanged -= UpdateScore;
    }

    private void Awake()
    {
        pausePanel.gameObject.SetActive(false);
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

    public void PauseButton()
    {
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SaveButton()
    {

    }

    public void MissionButton()
    {

    }

    public void MainMenu()
    {
        SceneController.Instance.MainMenuScene();

        Time.timeScale = 1f;
    }
}
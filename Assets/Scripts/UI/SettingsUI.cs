using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    // Reference to the back button
    [SerializeField] private Button backButton;

    // Audio Settings
    [Header("Audio Settings")]
    [SerializeField] private Button audioButton;
    [SerializeField] private GameObject audioUI;
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private TMP_Dropdown subtilesDropdown;

    // Video Settings
    [Header("Video Settings")]
    [SerializeField] private Button videoButton;
    [SerializeField] private GameObject videoUI;
    [SerializeField] private TMP_Dropdown displayMode;
    [SerializeField] private TMP_Dropdown resolutionOption;

    // Control Settings
    [Header("Control Settings")]
    [SerializeField] private Button controlButton;

    // Graphics Settings
    [Header("Graphics Settings")]
    [SerializeField] private Button graphicsButton;

    // Gameplay Settings
    [Header("Gameplay Settings")]
    [SerializeField] private Button gameplayButton;

    // Language Settings
    [Header("Language Settings")]
    [SerializeField] private Button languageButton;

    // Accessibility Settings
    [Header("Accessibility Settings")]
    [SerializeField] private Button accessibilityButton;

    private void Awake()
    {
        // Show all settings menu buttons when the scene starts
        SettingsMenuButtons(true);

        // Display the Audio Settings panel by default
        ConfigureAudioSettings(true);

        // Hide the Video Settings panel initially
        ConfigureVideoSettings(false);
    }

    // Return to the main menu scene
    public void BackButton()
    {
        SceneController.Instance.MainMenuScene();
    }

    // Open Audio Settings and hide all other settings panels
    public void AudioButton()
    {
        ConfigureAudioSettings(true);

        ConfigureVideoSettings(false);
        ConfigureControlSettings(false);
        ConfigureGraphicsSettings(false);
        ConfigureGameplaySettings(false);
        ConfigureLanguageSettings(false);
        ConfigureAccesibilitySettings(false);
    }

    // Open Video Settings and hide all other settings panels
    public void VideoButton()
    {
        ConfigureVideoSettings(true);

        ConfigureAudioSettings(false);
        ConfigureControlSettings(false);
        ConfigureGraphicsSettings(false);
        ConfigureGameplaySettings(false);
        ConfigureLanguageSettings(false);
        ConfigureAccesibilitySettings(false);
    }

    // Open Control Settings and hide all other settings panels
    public void ControlButton()
    {
        ConfigureControlSettings(true);

        ConfigureAudioSettings(false);
        ConfigureVideoSettings(false);
        ConfigureGraphicsSettings(false);
        ConfigureGameplaySettings(false);
        ConfigureLanguageSettings(false);
        ConfigureAccesibilitySettings(false);
    }

    // Open Graphics Settings and hide all other settings panels
    public void GraphicsButton()
    {
        ConfigureGraphicsSettings(true);

        ConfigureAudioSettings(false);
        ConfigureVideoSettings(false);
        ConfigureControlSettings(false);
        ConfigureGameplaySettings(false);
        ConfigureLanguageSettings(false);
        ConfigureAccesibilitySettings(false);
    }

    // Open Gameplay Settings and hide all other settings panels
    public void GameplayButton()
    {
        ConfigureGameplaySettings(true);

        ConfigureAudioSettings(false);
        ConfigureVideoSettings(false);
        ConfigureGraphicsSettings(false);
        ConfigureControlSettings(false);
        ConfigureLanguageSettings(false);
        ConfigureAccesibilitySettings(false);
    }

    // Open Language Settings and hide all other settings panels
    public void LanguageButton()
    {
        ConfigureLanguageSettings(true);

        ConfigureAudioSettings(false);
        ConfigureVideoSettings(false);
        ConfigureGraphicsSettings(false);
        ConfigureGameplaySettings(false);
        ConfigureControlSettings(false);
        ConfigureAccesibilitySettings(false);
    }

    // Open Accessibility Settings and hide all other settings panels
    public void AccessibilityButton()
    {
        ConfigureAccesibilitySettings(true);

        ConfigureAudioSettings(false);
        ConfigureVideoSettings(false);
        ConfigureGraphicsSettings(false);
        ConfigureGameplaySettings(false);
        ConfigureLanguageSettings(false);
        ConfigureControlSettings(false);
    }

    // Show or hide the Audio Settings panel and its UI elements
    private void ConfigureAudioSettings(bool condition)
    {
        audioUI.gameObject.SetActive(condition);
        VolumeSlider.gameObject.SetActive(condition);
        subtilesDropdown.gameObject.SetActive(condition);
    }

    // Show or hide the Video Settings panel and its UI elements
    private void ConfigureVideoSettings(bool condition)
    {
        videoUI.gameObject.SetActive(condition);
        displayMode.gameObject.SetActive(condition);
        resolutionOption.gameObject.SetActive(condition);
    }

    // Show or hide the Control Settings panel
    private void ConfigureControlSettings(bool condition)
    {
        // Control Settings UI configuration will be added here
    }

    // Show or hide the Graphics Settings panel
    private void ConfigureGraphicsSettings(bool condition)
    {
        // Graphics Settings UI configuration will be added here
    }

    // Show or hide the Gameplay Settings panel
    private void ConfigureGameplaySettings(bool condition)
    {
        // Gameplay Settings UI configuration will be added here
    }

    // Show or hide the Language Settings panel
    private void ConfigureLanguageSettings(bool condition)
    {
        // Language Settings UI configuration will be added here
    }

    // Show or hide the Accessibility Settings panel
    private void ConfigureAccesibilitySettings(bool condition)
    {
        // Accessibility Settings UI configuration will be added here
    }

    // Show or hide all settings menu navigation buttons
    private void SettingsMenuButtons(bool condition)
    {
        backButton.gameObject.SetActive(condition);

        audioButton.gameObject.SetActive(condition);
        videoButton.gameObject.SetActive(condition);
        controlButton.gameObject.SetActive(condition);
        gameplayButton.gameObject.SetActive(condition);
        graphicsButton.gameObject.SetActive(condition);
        languageButton.gameObject.SetActive(condition);
        accessibilityButton.gameObject.SetActive(condition);
    }
}
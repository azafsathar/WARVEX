using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    // Reference to the loading bar UI image
    [SerializeField] private Image loadingBar;

    // Reference to the text that displays loading progress
    [SerializeField] private TextMeshProUGUI loadingProgress;

    // Tracks the time spent on the loading screen
    private float time = 0f;

    // Stores the loading progress (0 to 1)
    private float progress = 0f;

    // Total duration of the loading screen in seconds
    private float duration = 5f;

    private void Update()
    {
        // Increase the timer every frame
        time += Time.deltaTime;

        // Calculate loading progress smoothly from 0 to 1
        progress = Mathf.Lerp(0f, 1f, time / duration);

        // Update the loading bar fill based on progress
        loadingBar.fillAmount = progress;

        // Display loading progress as a percentage
        loadingProgress.text = "Loading... " + Mathf.RoundToInt(progress * 100f) + "%";

        // Check whether the loading progress is complete
        if (progress >= 1)
        {
            // Switch to the gameplay scene
            SceneController.Instance.GameplayScene();
        }
    }
}
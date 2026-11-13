using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Stores the player's current score (other scripts can only read it)
    public float CurrentScore { get; private set; }

    // Static event to notify other scripts whenever the score changes
    public static event Action<float> OnScoreChanged;

    private void OnEnable()
    {
        // Listen for the score collection event
        CollectibleController.OnScoreCollected += AddScore;
    }

    private void OnDisable()
    {
        // Stop listening for the score collection event
        CollectibleController.OnScoreCollected -= AddScore;
    }

    private void Start()
    {
        // Initialize the score when the game starts
        ResetScore();
    }

    // Add points to the player's current score
    public void AddScore(float amount)
    {
        // Ignore zero or negative score amounts
        if (amount <= 0)
            return;

        // Increase the current score
        CurrentScore += amount;

        // Notify other scripts about the updated score
        OnScoreChanged?.Invoke(CurrentScore);
    }

    // Reset the player's score to zero
    public void ResetScore()
    {
        // Set the current score to zero
        CurrentScore = 0;

        // Notify other scripts about the reset score
        OnScoreChanged?.Invoke(CurrentScore);
    }
}
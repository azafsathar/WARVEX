using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Maximum health the player can have
    private float maxHealth = 100f;

    // Stores the player's current health
    public float CurrentHealth;

    // Static event to notify other scripts whenever player health changes
    public static event Action<float> OnHealthChanged;

    // Event to notify other scripts when the player dies
    public event Action OnPlayerDied;

    // Tracks whether the player is already dead
    private bool isDead;

    private void Awake()
    {
        // Set player health to maximum when the game starts
        CurrentHealth = maxHealth;
    }

    private void OnEnable()
    {
        // Listen for damage events from the ObstacleController
        EnemyController.OnDamageTaken += TakeDamage;
    }

    private void OnDisable()
    {
        // Stop listening for damage events when this script is disabled
        EnemyController.OnDamageTaken -= TakeDamage;
    }

    private void Start()
    {
        // Notify other scripts about the player's initial health
        OnHealthChanged?.Invoke(CurrentHealth);
    }

    // Reduce player health when damage is received
    public void TakeDamage(float amount)
    {
        // Prevent damage if the player is already dead
        if (isDead)
            return;

        // Reduce health and keep it between zero and maximum health
        CurrentHealth = Mathf.Clamp(CurrentHealth - amount, 0f, maxHealth);

        // Notify other scripts about the updated health
        OnHealthChanged?.Invoke(CurrentHealth);

        // Check whether the player's health has reached zero
        if (CurrentHealth <= 0f)
        {
            // Mark the player as dead
            isDead = true;

            // Notify other scripts that the player has died
            OnPlayerDied?.Invoke();
        }
    }

    // Restore player health
    public void Heal(float amount)
    {
        // Prevent healing if the player is dead or the amount is invalid
        if (isDead || amount <= 0f)
            return;

        // Increase health without exceeding maximum health
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0f, maxHealth);

        // Notify other scripts about the updated health
        OnHealthChanged?.Invoke(CurrentHealth);
    }
}
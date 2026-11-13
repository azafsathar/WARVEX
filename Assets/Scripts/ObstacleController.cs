using System;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // Static event to notify other scripts when the player takes damage
    public static event Action<float> OnDamageTaken;

    // Called when another collider enters the obstacle's trigger area
    private void OnTriggerEnter(Collider other)
    {
        // Check whether the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Notify other scripts that the player has taken 25 damage
            OnDamageTaken?.Invoke(25);

            // Destroy the obstacle after the collision
            Destroy(gameObject);
        }
    }
}
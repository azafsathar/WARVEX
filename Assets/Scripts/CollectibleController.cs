using System;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    // Static event to notify other scripts when a collectible is collected
    public static event Action<float> OnScoreCollected;

    private void Update()
    {
        // Rotate the collectible around its Y-axis
        transform.Rotate(Vector3.up * 60f * Time.deltaTime);
    }

    // Called when another collider enters the collectible's trigger area
    private void OnTriggerEnter(Collider other)
    {
        // Check whether the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Notify other scripts that the player collected 1 score point
            OnScoreCollected?.Invoke(1);

            // Destroy the collected object
            Destroy(gameObject);
        }
    }
}
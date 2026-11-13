using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Reference to the NavMeshAgent component
    private NavMeshAgent agent;

    // Static event to notify other scripts when the player takes damage
    public static event Action<float> OnDamageTaken;

    // Reference to the player's Transform
    [SerializeField] private Transform player;

    private void Awake()
    {
        // Get the NavMeshAgent component attached to the enemy
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Set the player's current position as the enemy's destination
        agent.SetDestination(player.position);
    }

    // Called when another collider enters the obstacle's trigger area
    private void OnTriggerEnter(Collider other)
    {
        // Check whether the object that entered the trigger is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Notify other scripts that the player has taken 25 damage
            OnDamageTaken?.Invoke(25);

            // Destroy the obstacle after the collision
            Destroy(gameObject);
        }
    }

}
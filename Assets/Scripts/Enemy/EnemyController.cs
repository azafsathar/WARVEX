using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Reference to the NavMeshAgent component
    private NavMeshAgent agent;

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
}
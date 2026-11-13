using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton instance to access AudioManager from other scripts
    public static AudioManager Instance { get; private set; }

    // Reference to the AudioSource component
    private AudioSource audioSource;

    // Audio clips for different gameplay actions
    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioClip damageSound;

    private void Awake()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Set this object as the Singleton instance
        Instance = this;

        // Keep this AudioManager alive when switching scenes
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        // Subscribe to the event when the player collects a score
        CollectibleController.OnScoreCollected += PlayScoreSound;

        // Subscribe to the event when the player takes damage
        ObstacleController.OnDamageTaken += PlayDamageSound;
    }

    private void OnDisable()
    {
        // Unsubscribe from the score collection event
        CollectibleController.OnScoreCollected -= PlayScoreSound;

        // Unsubscribe from the damage event
        ObstacleController.OnDamageTaken -= PlayDamageSound;
    }

    // Play the sound when the player collects a score
    private void PlayScoreSound(float score)
    {
        // Play the score sound without interrupting other sounds
        audioSource.PlayOneShot(scoreSound);
    }

    // Play the sound when the player takes damage
    private void PlayDamageSound(float score)
    {
        // Play the damage sound without interrupting other sounds
        audioSource.PlayOneShot(damageSound);
    }
}
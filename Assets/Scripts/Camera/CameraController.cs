using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the target the camera should follow (usually the player)
    [SerializeField] private Transform cameraTarget;

    // Camera position offset relative to the target
    [SerializeField] private Vector3 offset = new Vector3(0f, 2.5f, -2f);

    // Limits how far the camera can rotate vertically
    [SerializeField] private float minPitch = -30f;
    [SerializeField] private float maxPitch = 60f;

    // Controls how fast the camera rotates based on mouse movement
    private float sensitivity = 0.15f;

    // Horizontal and vertical camera rotation values
    private float yaw;
    private float pitch;

    // Stores mouse movement input
    private Vector2 lookInput;

    // Reference to the Input System
    private InputSystem_Actions controls;

    private void Awake()
    {
        // Create the Input System controls
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        // Enable camera look input
        controls.Player.Look.Enable();
    }

    private void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;

        // Hide the cursor during gameplay
        Cursor.visible = false;

        // Get the target's initial horizontal and vertical rotation
        yaw = cameraTarget.eulerAngles.y;
        pitch = cameraTarget.eulerAngles.x;
    }

    private void Update()
    {
        // Read mouse movement input
        lookInput = controls.Player.Look.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        // Update horizontal rotation using mouse X movement
        yaw += lookInput.x * sensitivity;

        // Update vertical rotation using mouse Y movement
        pitch -= lookInput.y * sensitivity;

        // Restrict vertical rotation within the defined limits
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // Convert yaw and pitch values into a rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        // Calculate the camera position using the target position and offset
        transform.position =
            cameraTarget.position + rotation * offset;

        // Make the camera look at the target
        transform.LookAt(cameraTarget.position);
    }

    private void OnDisable()
    {
        // Disable camera look input
        controls.Player.Look.Disable();

        // Unlock the cursor when the camera is disabled
        Cursor.lockState = CursorLockMode.None;

        // Make the cursor visible again
        Cursor.visible = true;
    }
}
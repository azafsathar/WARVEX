using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference to the player's health script
    private PlayerHealth playerHealth;

    // Input System
    private InputSystem_Actions controls;
    private Vector2 moveInput;

    // Player Components
    private CharacterController playerController;
    private Animator playerAnim;

    // Reference to the camera for camera-relative movement
    [SerializeField] private Transform cameraTransform;

    // Movement Settings
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float runSpeed = 2f;
    [SerializeField] private float rotationSpeed = 10f;

    // Jump and Gravity Settings
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float gravity = -9.81f;

    // Stores the current movement speed
    private float currentSpeed;

    // Player States
    private float verticalVelocity;
    private bool isRunning;
    private bool jumpRequested;
    private bool isGrounded;
    private bool isMoving;


    private void Awake()
    {
        // Create the Input System controls
        controls = new InputSystem_Actions();

        // Get the required components from the player
        playerHealth = GetComponent<PlayerHealth>();
        playerController = GetComponent<CharacterController>();
        playerAnim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // Enable player input actions
        controls.Player.Enable();

        // Listen for the player's death event
        playerHealth.OnPlayerDied += Die;
    }

    private void OnDisable()
    {
        // Disable player input actions
        controls.Player.Disable();

        // Stop listening for the player's death event
        playerHealth.OnPlayerDied -= Die;
    }


    private void Update()
    {
        // Read the player's input every frame
        ReadPlayerInput();

        // Handle player movement
        HandleMovement();

        // Handle jumping
        HandleJump();

        // Apply gravity to the player
        ApplyGravity();

        // Update player animations
        UpdateAnimation();
    }

    // Read movement, sprint, and jump inputs
    private void ReadPlayerInput()
    {
        // Read movement input (WASD or left stick)
        moveInput = controls.Player.Move.ReadValue<Vector2>();

        // Check whether the sprint button is held
        isRunning = controls.Player.Sprint.IsPressed();

        // Check whether the player is moving
        isMoving = moveInput.sqrMagnitude > 0.01f;

        // Check whether the jump button was pressed this frame
        if (controls.Player.Jump.WasPressedThisFrame())
        {
            jumpRequested = true;
        }
    }

    // Calculate movement direction based on the camera's direction
    private Vector3 CameraRelativeMovement()
    {
        // Get the camera's forward and right directions
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        // Remove the vertical direction to keep movement on the ground
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        // Normalize camera directions to get consistent movement directions
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate movement direction relative to the camera
        Vector3 movementDirection =
            cameraForward * moveInput.y +
            cameraRight * moveInput.x;

        // Prevent the player from moving faster diagonally
        if (movementDirection.sqrMagnitude > 1f)
        {
            movementDirection.Normalize();
        }

        return movementDirection;
    }

    // Handle player movement and apply the final movement
    private void HandleMovement()
    {
        // Choose between walking speed and running speed
        currentSpeed = isRunning ? runSpeed : walkSpeed;

        // Get the movement direction relative to the camera
        Vector3 movementDirection = CameraRelativeMovement();

        // Rotate the player towards the movement direction
        HandleRotation(movementDirection);

        // Calculate movement using direction and speed
        Vector3 finalMovement = movementDirection * currentSpeed;

        // Add vertical movement for jumping and falling
        finalMovement.y = verticalVelocity;

        // Move the player using CharacterController
        playerController.Move(finalMovement * Time.deltaTime);
    }

    // Rotate the player towards the movement direction
    private void HandleRotation(Vector3 movementDirection)
    {
        // Rotate only when the player moves forward
        if (moveInput.y > 0.01f)
        {
            // Calculate the rotation needed to face the movement direction
            Quaternion targetRotation =
                Quaternion.LookRotation(movementDirection);

            // Smoothly rotate the player towards the target rotation
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    // Handle player jumping and ground detection
    private void HandleJump()
    {
        // Check whether the player is touching the ground
        isGrounded = playerController.isGrounded;

        // Keep the player slightly grounded when standing on the ground
        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        // Check whether a jump was requested
        if (jumpRequested)
        {
            // Allow jumping only when the player is on the ground
            if (isGrounded)
            {
                // Calculate the upward velocity required for the jump height
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);

                // Play the jump animation
                playerAnim.SetTrigger("Jump");
            }

            // Reset the jump request
            jumpRequested = false;
        }
    }

    // Continuously apply gravity to make the player fall
    private void ApplyGravity()
    {
        verticalVelocity += gravity * Time.deltaTime;
    }


    // Update the player's animations based on movement and state
    private void UpdateAnimation()
    {
        // Pass horizontal and vertical movement input to the Animator
        playerAnim.SetFloat("MoveX", moveInput.x, 0.1f, Time.deltaTime);
        playerAnim.SetFloat("MoveY", moveInput.y, 0.1f, Time.deltaTime);

        // Calculate the animation speed based on player movement
        float animationSpeed = 0f;

        // Set the animation speed only when the player is moving
        if (isMoving)
        {
            // Use a higher animation speed when running
            animationSpeed = isRunning ? 2f : 1f;
        }

        // Update the Blend Tree movement speed
        playerAnim.SetFloat("Speed", animationSpeed, 0.1f, Time.deltaTime);

        // Pass vertical velocity to the Animator for jump and fall animations
        playerAnim.SetFloat("VerticalVelocity", verticalVelocity, 0.1f, Time.deltaTime);

        // Pass ground detection state to the Animator
        playerAnim.SetBool("Grounded", isGrounded);
    }

    // Called when the player dies
    public void Die()
    {
        // Play the player's death animation
        playerAnim.SetTrigger("Die");
    }

    // Called automatically when the CharacterController hits another collider
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Get the Rigidbody attached to the object being hit
        Rigidbody body = hit.collider.attachedRigidbody;

        // Stop if the object has no Rigidbody or its Rigidbody is kinematic
        if (body == null || body.isKinematic)
            return;

        // Calculate the horizontal direction in which the object should be pushed
        Vector3 pushDirection = new Vector3(
            hit.moveDirection.x,
            0f,
            hit.moveDirection.z
        ).normalized;

        // Set the force used to push the object
        float pushPower = 3f;

        // Apply an instant force to the object
        body.AddForce(pushDirection * pushPower, ForceMode.Impulse);
    }
}
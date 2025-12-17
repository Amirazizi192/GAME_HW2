using UnityEngine;

public class BatmobileMovement : MonoBehaviour
{
    // -------------------- Movement Settings --------------------
    [Header("Movement")]
    public float normalSpeed = 5f;     // Speed in normal movement
    public float boostSpeed = 12f;     // Speed while holding Shift (boost)

    // -------------------- References --------------------
    [Header("References")]
    private Rigidbody2D rb;            // Rigidbody for physics-based movement
    private float currentSpeed;        // Current speed (normal or boost)
    private Camera mainCamera;          // Main camera reference for bounds

    void Start()
    {
        // Get required components at start
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Handle player movement input
        HandleMovement();

        // Prevent the batmobile from leaving the screen
        ClampPosition();
    }

    void HandleMovement()
    {
        // Forward and backward movement (W / S)
        float forwardInput = Input.GetAxis("Vertical");

        // Side movement (A / D)
        float sideInput = 0f;
        if (Input.GetKey(KeyCode.A)) sideInput = -1f;
        if (Input.GetKey(KeyCode.D)) sideInput = 1f;

        // Check if boost key is pressed
        bool isBoosting = Input.GetKey(KeyCode.LeftShift);
        currentSpeed = isBoosting ? boostSpeed : normalSpeed;

        // Calculate movement directions
        Vector2 forwardMove = transform.up * forwardInput * currentSpeed;
        Vector2 sideMove = transform.right * sideInput * currentSpeed;

        // Apply final velocity to the Rigidbody
        rb.linearVelocity = forwardMove + sideMove;
    }

    void ClampPosition()
    {
        // Get current position
        Vector3 pos = transform.position;

        // Manual screen boundaries (gameplay limits)
        float minX = -7.0f;
        float maxX =  7.0f;
        float minY = -4.0f;
        float maxY = -1.0f;

        // Clamp position inside defined bounds
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // Apply clamped position
        transform.position = pos;
    }
}

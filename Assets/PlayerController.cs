using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f; // movement speed
    public float jumpForce = 10f; // jump force
    public Rigidbody rb;
    private bool isGrounded; // is player on a ground

    private float objectWidth;
    private float objectHeight;

    private float maxXPosition; // max x-position within camera bounds
    private float minXPosition; // min x-position within camera bounds

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Ensure rotation is frozen

        objectWidth = transform.lossyScale.x;
        objectHeight = transform.lossyScale.y;

        CalculateCameraBounds();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetButtonDown("Jump");

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * 0.1f;

        // Apply movement to player
        rb.MovePosition(transform.position + movement);

        Vector3 viewPos = transform.position;
        Debug.Log("MIN: " + (minXPosition + objectWidth));
        Debug.Log("MAX: " + (maxXPosition - objectWidth));
        viewPos.x = Mathf.Clamp(viewPos.x, minXPosition + 2 * objectWidth, maxXPosition - 2 * objectWidth);
        transform.position = viewPos;

        // Check for jump input and if the player is grounded
        if (jumpInput && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide");
        // Check if the player is grounded when colliding with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void CalculateCameraBounds()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            float distanceFromCamera = Vector3.Distance(transform.position, mainCamera.transform.position);
            float halfFOV = mainCamera.fieldOfView * 0.5f * Mathf.Deg2Rad;

            float aspectRatio = Screen.width / (float)Screen.height;
            float cameraHeight = distanceFromCamera * Mathf.Tan(halfFOV);
            float cameraWidth = cameraHeight * aspectRatio;

            // Calculate bounds of the camera (viewport)
            float maxX = mainCamera.transform.position.x + cameraWidth;
            float minX = mainCamera.transform.position.x - cameraWidth;

            Debug.Log("CALCMIN: " + minX);
            Debug.Log("CALCMAN: " + maxX);
            maxXPosition = maxX;
            minXPosition = minX;
        }
        else
        {
            Debug.LogError("Main camera not found");
        }
    }

}

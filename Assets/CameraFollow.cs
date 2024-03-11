using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;  // Offset distance between the camera and the player
    public float followSpeed = 5f; // camera follow speed

    private Rigidbody playerRigidbody;

    public float yOffset = 2f; // Offset fromplayer's y position

    void Update()
    {
        float targetY = player.position.y + yOffset;

        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.Lerp(transform.position.y, targetY, Time.deltaTime * 10f); // 10f adjust for speed interp.
        transform.position = newPosition;
    }
}

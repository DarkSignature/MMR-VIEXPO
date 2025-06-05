using System.Collections;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform cameraTransform; // Assign your main camera
    public Vector3 moveOffset = new Vector3(0, 0, 1.5f); // Move direction relative to camera
    public Vector3 minBounds = new Vector3(-10f, 0f, -10f);
    public Vector3 maxBounds = new Vector3(10f, 0f, 10f);

    private Rigidbody rb;
    public bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 moveDir = cameraTransform.forward;
            moveDir.y = 0; // Stay on XZ plane
            moveDir.Normalize();

            Vector3 targetPosition = rb.position + moveDir * moveSpeed * Time.fixedDeltaTime;

            // Clamp to boundaries
            // if (IsWithinBounds(targetPosition))
            // {
                rb.MovePosition(targetPosition);
            // }
        }
    }

    public void ToggleMovement()
    {
        isMoving = !isMoving;
    }

    private bool IsWithinBounds(Vector3 pos)
    {
        return pos.x >= minBounds.x && pos.x <= maxBounds.x &&
               pos.z >= minBounds.z && pos.z <= maxBounds.z;
    }
}

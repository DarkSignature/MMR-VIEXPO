using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    /// <summary>
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    public Material InactiveMaterial;

    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    public Material GazedAtMaterial;

    private Renderer _myRenderer;

    public Transform cameraTransform; // Drag the Main Camera here in the Inspector
    // public Vector3 offset = new Vector3(0, -1.5f, 0); // Adjust Y and Z to your liking

    // bool canMove = false;

    public float distanceInFront = 1.5f;
    public float groundOffsetY = -1.5f;

    // float moveCooldown = 1.0f; // seconds
    // float moveTimer = 0f;

    public PlayerMovementController movementController;
    private int overlapCount = 0;

    // public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
        _myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardDir = cameraTransform.forward;
        forwardDir.y = 0; // Only move on XZ plane
        forwardDir.Normalize();

        transform.position = cameraTransform.position + forwardDir * distanceInFront + Vector3.up * groundOffsetY;
        transform.LookAt(cameraTransform.position); // Optional: face the camera

        // moveTimer += Time.deltaTime;
        // if (canMove && moveTimer >= moveCooldown)
        // {
        //     cameraTransform.parent.position += cameraTransform.forward * 0.1f;
        //     moveTimer = 0f; // reset timer
        // }
    }

    void LateUpdate()
    {
        // Position in front of the camera with an offset
        // transform.position = cameraTransform.position + cameraTransform.forward * offset.z;
    }

    public void OnPointerEnter()
    {
        SetMaterial(true);
        movementController.isMoving = true;
    }

    public void OnPointerClick()
    {
        movementController.ToggleMovement();
    }

    public void OnPointerExit()
    {
        SetMaterial(false);
        movementController.isMoving = false;
        // canMove = false;
    }


    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        overlapCount++;
        _myRenderer.enabled = false;
    }

    void OnTriggerExit(Collider other)
    {
        overlapCount--;
        if (overlapCount <= 0)
        {
            _myRenderer.enabled = true;
        }
    }

}

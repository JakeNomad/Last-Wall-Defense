using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    [Header("Elements")]
    private Rigidbody playerRb;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotationSpeed = 600f;

    [Header("Control")]
    private float verticalInput;
    private float horizontalInput;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Daha okunabilir hale getirilebilir
        Vector3 targetVelocity = new Vector3(verticalInput, 0f, -horizontalInput) * moveSpeed;

        if (playerRb != null)
        {
            playerRb.linearVelocity = new Vector3(
                targetVelocity.x,
                playerRb.linearVelocity.y,
                targetVelocity.z
            );
        }

        if (horizontalInput != 0 || verticalInput != 0)
        {
            RotateCharacter(targetVelocity);
        }
    }
    
    private void RotateCharacter(Vector3 movementDirection)
    {
        // Dont move in y direction
        movementDirection.y = 0;

        // If there is a velocity direction
        if(movementDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);

            // Soft translate through current transform and target transform
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}



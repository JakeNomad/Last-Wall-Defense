using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    [Header("Elements")]
    private Rigidbody playerRb;
    private Animator playerAnim;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotationSpeed = 600f;

    [Header("Control")]
    private float verticalInput;
    private float horizontalInput;

    [Header("Animation")]
    private readonly int isRunningHash = Animator.StringToHash("IsRunning");

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        bool isMoving = (horizontalInput != 0 || verticalInput != 0);

        // Assing the animation parameter
        playerAnim.SetBool(isRunningHash, isMoving);

        // If there is a not movement. Do not continue to rigidbody physics.
        if (!isMoving)
        {
            playerRb.linearVelocity = new Vector3(0, playerRb.linearVelocity.y, 0);
            return;
        }

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

        RotateCharacter(targetVelocity);      
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



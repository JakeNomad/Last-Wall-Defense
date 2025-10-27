using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    [Header("Elements")]
    private TurretController turretController;
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
        turretController = GetComponent<TurretController>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        bool isMoving = (horizontalInput != 0 || verticalInput != 0);
    
        // For stoping animation while using turret
        bool shouldBeRunning = isMoving && !turretController.IsOnTurrent();
        playerAnim.SetBool(isRunningHash, shouldBeRunning);
    }

    void FixedUpdate()
    {
        if (!turretController.IsOnTurrent())
        {
            Move();    
        }
        else
        {
            playerRb.linearVelocity = new Vector3(0, playerRb.linearVelocity.y, 0);
        }
    }

private void Move()
{
    bool isMoving = (horizontalInput != 0 || verticalInput != 0);

    if (!isMoving)
    {
        playerRb.linearVelocity = new Vector3(0, playerRb.linearVelocity.y, 0);
        return;
    }

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



using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    [Header("Elements")]
    private Rigidbody playerRb;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpAmount = 5f;

    [Header("Control")]
    private float horizontalInput;
    private const float RightRotationY = 90f;
    private bool isOnGround;
   


    void Start()
    {
        isOnGround = true;
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //x ekseni hareketi
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed;

        if (playerRb != null)
        {
            playerRb.linearVelocity = new Vector3(movement.x, playerRb.linearVelocity.y, playerRb.linearVelocity.z);

            // Hareket olduğunda
            if (horizontalInput != 0)
                FlipCharacter(horizontalInput);
        }
    }

    private void Jump()
    {
        // Space bastığın zaman
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            playerRb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
            isOnGround = true;
    }
    
    // Karakterin x ekseninde modelinin dönmesini sağlayan, inputu kontrol eden fonksiyon
    private void FlipCharacter(float direction)
    {
        Quaternion targetRotation = transform.rotation;

        if (direction < 0)
        {
            // Sola dönecek rotasyon, -90 derece için Euler methodu.
            targetRotation = Quaternion.Euler(0, -RightRotationY, 0);
        }
        else if (direction > 0)
        {
            // Sağa dönecek rotasyon, 90 derece için Euler methodu.
            targetRotation = Quaternion.Euler(0, RightRotationY, 0);
        }

        transform.rotation = targetRotation;
    }
}



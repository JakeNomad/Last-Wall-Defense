using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Elements")]
    public Camera mainCam;
    public Camera turretCam;

    public Transform turretPivot;


    private TurretController turretController;
    private float horizontalInput;
    private float verticalInput;

    [Header("Settings")]
    [SerializeField] private float lookSensitivity = 5f;
    [SerializeField] private float verticalRotationLimit = 80f;

    [SerializeField] private float minHorizontalLimit = -90f; 
    [SerializeField] private float maxHorizontalLimit = 90f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        turretController = GameObject.Find("Player").gameObject.GetComponent<TurretController>();
        
        mainCam.enabled = true;
        turretCam.enabled = false;

        rotationY = turretPivot.localEulerAngles.y;
        rotationX = turretPivot.localEulerAngles.z;
    }

    void Update()
    {
        if (ActivateTurretCam())
        {
            HandleTurretCameraRotation();
        }
    }

    private void HandleTurretCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;

        // === For Y===
        rotationY += mouseX;
        rotationY = Mathf.Clamp(rotationY, minHorizontalLimit, maxHorizontalLimit);

        // === For X ===
        rotationX += mouseY;

        // Limiting the angle
        rotationX = Mathf.Clamp(rotationX, -verticalRotationLimit, verticalRotationLimit);
        
        turretPivot.localRotation = Quaternion.Euler(
            0f,         
            rotationY, 
            rotationX    
        );
    }

    private bool ActivateTurretCam()
    {
        if (turretController.IsOnTurrent())
        {
            mainCam.enabled = false;
            turretCam.enabled = true;
            return true;
        }
        else
        {
            mainCam.enabled = true;
            turretCam.enabled = false;
            return false;
        }
    }
}

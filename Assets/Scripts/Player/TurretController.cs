using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("Elements")]
    private bool isOnTurrent = false;

    public Transform turretPivot;

    private CameraSwitcher camSwitcher;
    private float horizontalInput;
    private float verticalInput;

    [Header("Settings")]
    [SerializeField] private float lookSensitivity = 300f;
    [SerializeField] private float verticalRotationLimit = 80f;

    [SerializeField] private float minHorizontalLimit = -90f;
    [SerializeField] private float maxHorizontalLimit = 90f;
    
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        camSwitcher = GameObject.Find("Camera Manager").gameObject.GetComponent<CameraSwitcher>();
        Cursor.lockState = CursorLockMode.Locked;

        rotationY = turretPivot.localEulerAngles.y;
        rotationX = turretPivot.localEulerAngles.z;
    }

    void Update()
    {
        if(camSwitcher.ActivateTurretCam())
        {
            HandleTurretCameraRotation();
        }
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Turret"))
        {
            isOnTurrent = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("Turret"))
        {
            isOnTurrent = false;
        }
    }

    public bool IsOnTurrent()
    {
        return isOnTurrent;
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
}

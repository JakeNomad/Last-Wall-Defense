using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Elements")]
    public Camera mainCam;
    public Camera turretCam;
    private TurretController turretController;

    private float horizontalInput;
    private float verticalInput;

    private float rotationY;
    private float rotationX;

    [Header("Settings")]
    [SerializeField] private float rotationSpeed = 1f;

    void Start()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        turretController = GameObject.Find("Player").gameObject.GetComponent<TurretController>();
        
        mainCam.enabled = true;
        turretCam.enabled = false;
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

        rotationY += horizontalInput * rotationSpeed * Time.deltaTime;
        rotationX -= verticalInput * rotationSpeed * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
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

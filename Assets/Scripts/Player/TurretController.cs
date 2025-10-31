using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("Elements")]
    private bool isOnTurrent = false;
    private bool canShoot = false;

    public Transform turretPivot;

    [Header("Shooting Components")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 50f;

    private CameraSwitcher camSwitcher;
    private UI ui;

    [Header("Settings")]
    [SerializeField] private float lookSensitivity = 300f;
    [SerializeField] private float verticalRotationLimit = 80f;

    [SerializeField] private float minHorizontalLimit = -90f;
    [SerializeField] private float maxHorizontalLimit = 90f;

    // Fire Rate Settings
    [SerializeField] private float fireRate = 0.2f;
    private float nextFireTime = 0f;
    
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        camSwitcher = GameObject.Find("Camera Manager").gameObject.GetComponent<CameraSwitcher>();
        Cursor.lockState = CursorLockMode.Locked;

        ui = GameObject.Find("UI").gameObject.GetComponent<UI>();

        rotationY = turretPivot.localEulerAngles.y;
        rotationX = turretPivot.localEulerAngles.z;
    }

    void Update()
    {
        if(camSwitcher.ActivateTurretCam())
        {
            isOutofBullet();
            Shoot();
            HandleTurretCameraRotation();
        }
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Turret"))
        {
            isOnTurrent = true;
            canShoot = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("Turret"))
        {
            isOnTurrent = false;
            canShoot = false;
        }
    }

    public bool IsOnTurrent()
    {
        return isOnTurrent;
    }

    private void HandleTurretCameraRotation()
    {
        StopUsingTurret();

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

    private void Shoot()
    {
        if (canShoot && Input.GetKey(KeyCode.Mouse0))
        {
            // Fire Rate Control
            if (Time.time > nextFireTime)
            {
                nextFireTime = Time.time + fireRate;
                FireBullet();
                ui.DecreasedAmmo();
            }
        }
    }

    private void FireBullet()
    {
        Vector3 direction = firePoint.right;

        // Mermiyi oluştuğu anda RigidBody componentini al
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();

        bulletRb.linearVelocity = direction * bulletSpeed;
    }

    private void isOutofBullet()
    {
        if (ui.GetAmmo() <= 0)
            canShoot = false;
    }
    
    private void StopUsingTurret()
    {
        Vector3 warpPosition = new Vector3(1.05f, 0.512f, -7.136f); 

        if(isOnTurrent)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = warpPosition;
            }
        }
    }
}

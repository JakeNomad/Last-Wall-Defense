using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Elements")]
    public Camera mainCam;
    public Camera turretCam;
    private TurretController turretController;

    void Start()
    {
        turretController = GameObject.Find("Player").gameObject.GetComponent<TurretController>();
        mainCam.enabled = true;
        turretCam.enabled = false;  
    }

    void Update()
    {
        if (turretController.IsOnTurrent())
        {
            turretCam.enabled = true;
            mainCam.enabled = false;
        }
        else
        {
            turretCam.enabled = false;
            mainCam.enabled = true;
        }
    }
}

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
    
    public bool ActivateTurretCam()
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

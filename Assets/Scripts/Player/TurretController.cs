using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("Elements")]
    private bool isOnTurrent = false;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Turret"))
        {
            Debug.Log("Entered on the Turret");
            isOnTurrent = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("Turret"))
        {
            Debug.Log("Exited on the Turret");
            isOnTurrent = false;
        }
    }

    public bool IsOnTurrent()
    {
        return isOnTurrent;
    }
}

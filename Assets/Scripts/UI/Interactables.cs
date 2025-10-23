using UnityEngine;

public class Interactables : MonoBehaviour
{
    [Header("Control")]
    public bool isInCollision = false;
    private int ammo;

    void Start()
    {
        ammo = 0;
    }

    void Update()
    {
        CanTakeAmmo();
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isInCollision = true;           
            Debug.Log("Entered");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isInCollision = false;
            Debug.Log("Exited");
        }
    }

    private void CanTakeAmmo()
    {
        if(isInCollision && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Ammo Taken!");
            IncreaseAmmo(1);
        }
    }

    private void IncreaseAmmo(int amount)
    {
        ammo += amount;
    }
    
    public int getAmmo()
    {
        return ammo;
    }
}

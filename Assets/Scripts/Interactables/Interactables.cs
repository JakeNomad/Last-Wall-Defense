using UnityEngine;

public class Interactables : MonoBehaviour
{
    [Header("Control")]
    protected bool isInCollision = false;

    [Header("Elements")]
    [SerializeField] private int maxAmmo = 20;
    private int ammo;
    
    void Start()
    {
        ammo = 0;
    }

    void Update()
    {
        CanTakeAmmo();
    }

    private void CanTakeAmmo()
    {
        // Max ammo amount that player carries
        if (ammo >= maxAmmo)
            return;

        
        if (isInCollision && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Ammo Taken!");
            IncreaseAmmo(1);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isInCollision = true;           
            Debug.Log("Entered");
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isInCollision = false;
            Debug.Log("Exited");
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
    
    public void resetAmmo()
    {
        ammo = 0;
    }
}

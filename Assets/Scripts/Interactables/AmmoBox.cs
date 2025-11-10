using UnityEngine;

public class AmmoBox : MonoBehaviour
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

        
        if (isInCollision && Input.GetKey(KeyCode.E))
        {
            IncreaseAmmo(1);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isInCollision = true;           
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isInCollision = false;
        }
    }

    private void IncreaseAmmo(int amount)
    {
        ammo += amount;
    }

    public void DecreasedAmmo()
    {
        if (ammo <= 0)
            return;
        
        ammo--;
    }

    public int GetAmmo()
    {
        return ammo;
    }
    
    public void ResetAmmo()
    {
        ammo = 0;
    }
}

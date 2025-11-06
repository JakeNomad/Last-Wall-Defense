using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Elements")]
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    private bool isDestroyed = false;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Door took damage. Remaining Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            DestroyDoor();
        }
    }

    public bool GetIsDestroyed()
    {
        return isDestroyed;
    }
    
    private void DestroyDoor()
    {
        isDestroyed = true;
        Debug.Log("Door got opened!");
        Destroy(gameObject);
    }
}

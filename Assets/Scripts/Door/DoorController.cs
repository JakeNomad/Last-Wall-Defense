using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Elements")]
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    private bool isDestroyed = false;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").gameObject.GetComponent<GameManager>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Door took damage. Remaining Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            DestroyDoor();
            gameManager.GameOver();
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

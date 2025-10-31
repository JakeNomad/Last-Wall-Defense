using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private int damage = 1;
    private float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
            Debug.Log("Bullet Hit!");
        }
        
        Destroy(gameObject);
    }
}

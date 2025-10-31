using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Components")]
    public ParticleSystem bloodEffect;

    [Header("Elements")]
    [SerializeField] private int enemyHealth = 5;

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        bloodEffect.Play();
        Debug.Log(enemyHealth);
        enemyHealth -= amount;
    }
}

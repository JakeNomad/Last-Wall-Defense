using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Components")]
    public ParticleSystem bloodEffect;
    private Animator enemyAnimator;
    private EnemyController enemyController;

    private float timer = 0f;

    [Header("Elements")]
    [SerializeField] private int enemyHealth = 5;
    private bool canBleed = true;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            canBleed = false;
            enemyController.canMove = false;
            enemyAnimator.SetBool("isDead", true);
            DestroyAfterSomeSecond(1.2f);
        }
    }

    public void TakeDamage(int amount)
    {
        if (canBleed)
            bloodEffect.Play();
        
        Debug.Log(enemyHealth);
        enemyHealth -= amount;
    }

    private void DestroyAfterSomeSecond(float destroyTime)
    {
        timer += Time.deltaTime;
        if(timer >= destroyTime)
        {
            Destroy(gameObject);
        }
    }
}

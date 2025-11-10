using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Components")]
    public ParticleSystem bloodEffect;
    private Animator enemyAnimator;
    private EnemyController enemyController;
    private Collider enemyCollider;

    private float timer = 0f;

    [Header("Elements")]
    [SerializeField] private int enemyHealth = 5;
    private bool canBleed = true;

    [Header("Sounds")]
    private SoundManager soundManager;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider>();
        enemyController = GetComponent<EnemyController>();
        soundManager = GameObject.Find("Sound Manager").gameObject.GetComponent<SoundManager>();
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            canBleed = false;
            enemyCollider.isTrigger = true;
            enemyController.canMove = false;
            enemyAnimator.SetBool("isDead", true);
            DestroyAfterSomeSecond(1.2f);
        }
    }

    public void TakeDamage(int amount)
    {
        if (canBleed)
        {
            soundManager.PlayEnemyHitSound();
            bloodEffect.Play();
        }
        
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

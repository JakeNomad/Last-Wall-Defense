using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float rotationSpeed = 540f;
    private Transform doorPosition;
    private DoorController targetDoor;

    [Header("Enemy")]
    [SerializeField] private float damageAmount = 10f;
    private Vector3 moveDirection;
    

    private bool isOnDoor = false;
    public bool canMove = true;

    [Header("Animation")]
    private Animator enemyAnimation;
    private readonly int isAttackingHash = Animator.StringToHash("isOnDoor");

    void Start()
    {
        doorPosition = GameObject.Find("Door Trigger").gameObject.GetComponent<Transform>();
        targetDoor = GameObject.Find("Door").gameObject.GetComponent<DoorController>();
        enemyAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        if (doorPosition == null || targetDoor == null)
            return;
        
        if (canMove)
        {
            MoveToTheDoor();
            RotateDoor();
        }
    }
    
    private void MoveToTheDoor()
    {
        // Moving on a Doors Direction
        moveDirection = (doorPosition.position - transform.position).normalized;
        moveDirection.y = 0;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door Trigger"))
        {
            Debug.Log("Attack!");
            enemyAnimation.SetBool(isAttackingHash, true);
            isOnDoor = true;
            canMove = false;
        }
    }

    // Trigger through Animation frame event. (In Unity editor)
    public void InflictDamage()
    {
        if (targetDoor == null)
            return;
        
        targetDoor.TakeDamage(damageAmount);

        if(targetDoor.GetIsDestroyed())
        {
            enemyAnimation.SetBool(isAttackingHash, false);
        }
    }
    
    private void RotateDoor()
    {
        Vector3 directionToDoor = (doorPosition.position - transform.position);
        directionToDoor.y = 0;

        // If direction vector is not 0. (Far away from door)
        if (directionToDoor.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToDoor);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}

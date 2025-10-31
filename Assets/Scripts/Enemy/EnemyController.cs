using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float rotationSpeed = 540f;
    public Transform doorPosition;

    private Vector3 moveDirection;
    

    private bool isOnDoor = false;
    public bool canMove = true;

    [Header("Animation")]
    private Animator enemyAnimation;
    private readonly int isAttackingHash = Animator.StringToHash("isOnDoor");

    void Start()
    {
        enemyAnimation = GetComponent<Animator>();
    }
    
    void Update()
    {
        // Moving on a Doors Direction
        moveDirection = (doorPosition.position - transform.position).normalized;
        moveDirection.y = 0;

        if(canMove)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
            RotateDoor();
        }
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

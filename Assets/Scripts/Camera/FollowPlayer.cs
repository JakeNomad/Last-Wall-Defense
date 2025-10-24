using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Elements")]
    public GameObject player;

    [Header("Settings")]
    [SerializeField, Range(0.01f, 1f)] private float smoothSpeed = 0.2f;

    private Vector3 offset;
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void FixedUpdate()
    {
        SmoothFollow();
    }
    
    private void SmoothFollow()
    {
        Vector3 desiredPosition = player.transform.position + offset;

        // Vector3.Lerp fonk. için gerekli bileşenler (ilk pozisyon, sonraki pozisyonu, geçiş hızı)
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed
        );

        transform.position = smoothedPosition;
    }
}

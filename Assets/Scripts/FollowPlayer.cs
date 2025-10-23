using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Elements")]
    public GameObject player;

    [Header("Settings")]
    [SerializeField] private float smoothSpeed = 0.1f;
    private float offsetX = -0.14f;
    private float offsetY = -5.48f;
    private float offsetZ = 0.04f;
    
    void Start()
    {
        //Vector3 playerToCamera = (player.transform.position - transform.position);
        //Debug.Log(playerToCamera);
        // -0.14, -5.48, 0.04
    }

    void FixedUpdate()
    {
        SmoothFollow();
    }
    
    private void SmoothFollow()
    {
        Vector3 offset = new Vector3(offsetX, offsetY, offsetZ);
        Vector3 desiredPosition = player.transform.position - offset;

        // Vector3.Lerp fonk. için gerekli bileşenler (ilk pozisyon, sonraki pozisyonu, geçiş hızı)
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed
        );

        transform.position = smoothedPosition;
    }
}

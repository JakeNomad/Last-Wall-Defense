using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Elements")]
    public GameObject player;

    [Header("Settings")]
    private float offsetX = -0.64f;
    private float offsetY = -1.12f;
    private float offsetZ = 6.01f;
    
    void Start()
    {
        // Vector3 playerToCamera = (player.transform.position - transform.position);
        // Debug.Log(playerToCamera);
        // -0.64, -1.12 , 6.01
    }

    void FixedUpdate()
    {
        Vector3 offset = new Vector3(offsetX, offsetY, offsetZ);
        transform.position = player.transform.position - offset;
    }
}

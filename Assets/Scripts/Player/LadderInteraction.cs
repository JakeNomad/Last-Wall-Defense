using UnityEngine;

public class LadderInteraction : MonoBehaviour
{
    private Vector3 warpPosition;

    void Start()
    {
        warpPosition = new Vector3(3.582f, 2.849f, -7.362f);
    }


    void Update()
    {

    }
    
    // 3.582, 2.849, -7.362
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Ladder"))
        {
            transform.position = warpPosition;
        }
    }
}

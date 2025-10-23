using Unity.VisualScripting;
using UnityEngine;

public class ResettingAmmo : MonoBehaviour
{
    private Interactables interactables;

    void Start()
    {
        interactables = GameObject.Find("Ammo Box").gameObject.GetComponent<Interactables>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Ammo Reseter"))
        {
            interactables.resetAmmo();
        }
    }
}

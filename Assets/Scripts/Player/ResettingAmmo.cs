using Unity.VisualScripting;
using UnityEngine;

public class ResettingAmmo : MonoBehaviour
{
    private AmmoBox interactables;

    void Start()
    {
        interactables = GameObject.Find("Ammo Box").gameObject.GetComponent<AmmoBox>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Ammo Reseter"))
        {
            interactables.resetAmmo();
        }
    }
}

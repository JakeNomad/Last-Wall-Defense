using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [Header("Elements")]
    public TextMeshProUGUI ammoText;
    private Interactables interactable;
    
    void Start()
    {
        interactable = GameObject.Find("Ammo Box").gameObject.GetComponent<Interactables>();
        ammoText.text = "Ammo: " + 0;
    }

    void Update()
    {
        if (interactable != null)
            UpdateAmmoText();
    }
    
    private void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + interactable.getAmmo();
    }

}

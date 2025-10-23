using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [Header("Elements")]
    public TextMeshProUGUI ammoText;
    private AmmoBox ammoBox;
    
    void Start()
    {
        ammoBox = GameObject.Find("Ammo Box").gameObject.GetComponent<AmmoBox>();
        ammoText.text = "Ammo: " + 0;
    }

    void Update()
    {
        if (ammoBox != null)
            UpdateAmmoText();
    }
    
    private void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammoBox.getAmmo();
    }

}

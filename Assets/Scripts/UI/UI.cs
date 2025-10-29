using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [Header("Elements")]
    public TextMeshProUGUI ammoText;
    public GameObject crosshair;

    private AmmoBox ammoBox;
    private CameraSwitcher camSwitcher;
    
    
    void Start()
    {
        ammoBox = GameObject.Find("Ammo Box").gameObject.GetComponent<AmmoBox>();
        ammoText.text = "Ammo: " + 0;

        camSwitcher = GameObject.Find("Camera Manager").gameObject.GetComponent<CameraSwitcher>();
        crosshair.SetActive(false);
    }

    void Update()
    {
        if (ammoBox != null)
            UpdateAmmoText();

        CheckCrosshair();
    }

    private void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammoBox.getAmmo();
    }

    private void CheckCrosshair()
    {
        if (!camSwitcher.ActivateTurretCam())
        {
            crosshair.SetActive(false);
        }
        else
            crosshair.SetActive(true);
    }
}

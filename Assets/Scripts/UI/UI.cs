using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [Header("Elements")]
    public TextMeshProUGUI ammoText;
    public GameObject crosshair;
    public TextMeshProUGUI waveText;

    private AmmoBox ammoBox;
    private CameraSwitcher camSwitcher;
    private WaveManager waveManager;
    
    
    void Start()
    {
        waveManager = GameObject.Find("Wave Manager").gameObject.GetComponent<WaveManager>();

        ammoBox = GameObject.Find("Ammo Box").gameObject.GetComponent<AmmoBox>();
        ammoText.text = "Ammo: " + 0;

        camSwitcher = GameObject.Find("Camera Manager").gameObject.GetComponent<CameraSwitcher>();
        crosshair.SetActive(false);
    }

    void Update()
    {
        if (ammoBox != null)
            UpdateAmmoText();

        UpdateWaveIndex();
        CheckCrosshair();
    }

    private void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammoBox.GetAmmo();
    }

    private void UpdateWaveIndex()
    {
        waveText.text = "Wave: " + waveManager.GetWaveIndex();
    }

    public int GetAmmo()
    {
        return ammoBox.GetAmmo();
    }

    public void DecreasedAmmo()
    {
        ammoBox.DecreasedAmmo();
        UpdateAmmoText();       
    }

    private void CheckCrosshair()
    {
        // Check player whether using turret or not
        if (!camSwitcher.ActivateTurretCam())
        {
            crosshair.SetActive(false);
        }
        else
            crosshair.SetActive(true);
    }
}

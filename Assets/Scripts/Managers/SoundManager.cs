using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Turret")]
    [SerializeField] private AudioClip[] turretShoot;
    [SerializeField] private float turretShootPitch = 3.0f;
    [SerializeField] private float turretShootVolume = 0.1f;

    [Header("Enemy")]
    [SerializeField] private AudioClip[] enemyHit;
    [SerializeField] private float enemyHitPitch = 1.0f;
    [SerializeField] private float enemyHitVolume = 0.05f;

    [Header("Player")]
    [SerializeField] private AudioClip[] playerFootstep;
    [SerializeField] private float playerFootstepPitch = 1.0f;
    [SerializeField] private float playerFootstepVolume = 0.05f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFootstepSound()
    {
        if (audioSource == null) return;

        audioSource.pitch = playerFootstepPitch;
        audioSource.volume = playerFootstepVolume;

        int randSoundIndex = Random.Range(0, playerFootstep.Length);
        audioSource.PlayOneShot(playerFootstep[randSoundIndex]);
    }

    public void PlayTurretShootSound()
    {
        if (audioSource == null) return;

        audioSource.pitch = turretShootPitch;
        audioSource.volume = turretShootVolume;

        int randSoundIndex = Random.Range(0, turretShoot.Length);
        audioSource.PlayOneShot(turretShoot[randSoundIndex]);
    }
    
    public void PlayEnemyHitSound()
    {
        if (audioSource == null) return;

        audioSource.pitch = enemyHitPitch;
        audioSource.volume = enemyHitVolume;

        int randSoundIndex = Random.Range(0, enemyHit.Length);
        audioSource.PlayOneShot(enemyHit[randSoundIndex]);
    }
}

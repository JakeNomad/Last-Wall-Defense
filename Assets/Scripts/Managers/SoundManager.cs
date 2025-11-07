using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    // Turret
    public AudioClip[] turretShoot;

    // Enemy
    public AudioClip[] enemyHit;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayTurretShootSound()
    {
        if (audioSource == null) return;

        int randSoundIndex = Random.Range(0, turretShoot.Length);
        audioSource.PlayOneShot(turretShoot[randSoundIndex]);
    }
    
    public void PlayEnemyHitSound()
    {
        if (audioSource == null) return;

        int randSoundIndex = Random.Range(0, enemyHit.Length);
        audioSource.PlayOneShot(enemyHit[randSoundIndex]);
    }
}

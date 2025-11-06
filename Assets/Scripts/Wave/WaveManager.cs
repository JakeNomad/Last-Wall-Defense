using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Elements")]
    public GameObject enemyPrefab;

    [Header("Wave")]
    public int waveNumber = 1;

    private int enemyCount;
    private int enemySpawnPerWave;
    

    [Header("Control")]
    private bool isSpawning = false; 

    void Start()
    {
        enemySpawnPerWave = waveNumber;
        BeginTheWaves();
    }

    void Update()
    {
        enemyCount = FindObjectsByType<EnemyController>(FindObjectsSortMode.None).Length;

        if (enemyCount == 0 && !isSpawning) 
        {
            waveNumber++;
            enemySpawnPerWave = waveNumber; 
            StartCoroutine(SpawnEnemies(enemySpawnPerWave, 1.5f));
        }
    }
    
    private void BeginTheWaves()
    {
        StartCoroutine(SpawnEnemies(enemySpawnPerWave, 2f));
    }

    private IEnumerator SpawnEnemies(int count, float rate)
    {
        isSpawning = true;
        Debug.Log("Starting Wave " + waveNumber + " with " + count + " enemies.");

        for (int i = 0; i < count; i++)
        {
            Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
            yield return new WaitForSeconds(rate);
        }

        isSpawning = false;
        Debug.Log("Wave " + waveNumber + " spawn completed. Waiting for enemies to die.");
    }
    
    private Vector3 GetRandomPosition()
    {
        float randomXposition = Random.Range(24f, 27f);
        float randomZposition = Random.Range(-2f, -8f);

        Vector3 randomPosition = new Vector3(randomXposition, 0.5f, randomZposition);
        return randomPosition;  
    }

    public int GetWaveIndex()
    {
        return waveNumber;
    }
}
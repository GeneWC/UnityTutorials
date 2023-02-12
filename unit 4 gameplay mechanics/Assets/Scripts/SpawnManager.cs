using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private bool spawnPowerup = false;
    public float spawnRange = 9;
    public int enemyCount;

    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);

    }

    void SpawnEnemyWave(int enemiesCt)
    {
        for (int i = 0; i < enemiesCt; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0.0f, spawnPosZ);
        return randomPos;
    }
    IEnumerator powerUpSaver()
    {
        yield return new WaitForSeconds(30);
        spawnPowerup = true;

    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            int randPowerupDecider = Random.Range(-1, 2);
            Debug.Log(randPowerupDecider);
            spawnPowerup = randPowerupDecider > 0;
            if (randPowerupDecider <= 0) StartCoroutine(powerUpSaver());
            
            if (waveNumber < 4) waveNumber++;
            else if (waveNumber < 15) waveNumber += 2;
            else if (waveNumber < 30) waveNumber += 3;
            else waveNumber += 5;
            SpawnEnemyWave(waveNumber);
        }
        if (spawnPowerup)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            spawnPowerup = false;
        }
    }
}

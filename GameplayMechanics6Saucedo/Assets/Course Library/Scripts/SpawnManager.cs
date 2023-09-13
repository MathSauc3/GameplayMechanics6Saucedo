using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private float spawnmRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject[] powerupPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        int randomPowerup = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);
        SpawnEveryWave(waveNumber);
    }

    void SpawnEveryWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            int randomEnemy = Random.Range(0, enemyPrefab.Length);

            Instantiate(enemyPrefab[randomEnemy], GenerateSpawnPosition()
    , enemyPrefab[randomEnemy].transform.rotation);
        }
    }
        private Vector3 GenerateSpawnPosition()
        {
         float spawnPosX = Random.Range(-spawnmRange, spawnmRange);
         float spawnPosZ = Random.Range(-spawnmRange, spawnmRange);
         Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
         return randomPos;
        }
       
    

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEveryWave(waveNumber);
            int randomePowerup = Random.Range(0,powerupPrefabs.Length);
            Instantiate(powerupPrefabs[randomePowerup], GenerateSpawnPosition(), powerupPrefabs[randomePowerup].transform.rotation); ;
        }
    }
}

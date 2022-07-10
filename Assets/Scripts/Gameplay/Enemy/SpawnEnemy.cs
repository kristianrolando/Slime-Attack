using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform[] spawnPoint;
    public float timeSpawn = 1.3f;
    float time = 0;


    private void Update()
    {
        if (time <= 0)
        {
            RandomSpawnEnemyByPercentage();
            time = timeSpawn;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
    void RandomSpawnEnemyByPercentage()
    {
        int ranPoint = Random.Range(0, spawnPoint.Length);
        int randValue = Random.Range(1, 100);
        if (randValue <= 15) //heart 15%
            Instantiate(enemyPrefabs[0], spawnPoint[ranPoint].position, Quaternion.identity);
        else if(randValue > 15 && randValue <= 45) //wood 30%
            Instantiate(enemyPrefabs[1], spawnPoint[ranPoint].position, Quaternion.identity);
        else if(randValue > 45 && randValue <=75 ) //rock 30%
            Instantiate(enemyPrefabs[2], spawnPoint[ranPoint].position, Quaternion.identity);
        else if(randValue > 75) //Magma Rock 25%
            Instantiate(enemyPrefabs[3], spawnPoint[ranPoint].position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform[] spawnPoint;
    [SerializeField] float timeSpawn = 2f;
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
        if (randValue <= 15) //heart
            Instantiate(enemyPrefabs[0], spawnPoint[ranPoint].position, Quaternion.identity);
        else if(randValue > 15 && randValue <= 45) //wood
            Instantiate(enemyPrefabs[1], spawnPoint[ranPoint].position, Quaternion.identity);
        else if(randValue > 45 && randValue <=75 ) //rock
            Instantiate(enemyPrefabs[2], spawnPoint[ranPoint].position, Quaternion.identity);
        else if(randValue > 75) //Magma Rock
            Instantiate(enemyPrefabs[3], spawnPoint[ranPoint].position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoint;
    [SerializeField] private float timeSpawn = 2f;
    private float time = 0;

    private void Update()
    {
        int ranPoint = Random.Range(0, spawnPoint.Length);
        int ranPref = Random.Range(0, enemyPrefabs.Length);
        if (time <= 0)
        {
            Instantiate(enemyPrefabs[ranPref], spawnPoint[ranPoint].position, Quaternion.identity);
            time = timeSpawn;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}

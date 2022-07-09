using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] objectFalse;
    [SerializeField] GameObject[] objectTrue;

    //Set Enemy Stat
    public int maxLifeWood = 1;
    public int maxLifeRock = 1;
    public int maxLifeMagmaRock = 3;
    public int maxLifeHearth = 1;


    [SerializeField, Range(1, 100)] int increaseSpeed = 25;

    public float SpeedEnemy = 3f;
    [SerializeField] PlayerScore score;

    [HideInInspector] public float tempSpeed;
    bool isDifficult;
    int tempScore;
    private void Awake()
    {
        for(int i = 0; i < objectFalse.Length; i++)
        {
            objectFalse[i].SetActive(false);
        }
        for (int i = 0; i < objectTrue.Length; i++)
        {
            objectTrue[i].SetActive(true);
        }
    }

    private void Start()
    {
        tempSpeed = SpeedEnemy;
    }

    private void Update()
    {
        Difficulty();
    }
    void Difficulty()
    {
        if (score.scorePoint != tempScore)
        {
            isDifficult = true;
        }
        if (score.scorePoint % increaseSpeed == 0 && score.scorePoint != 0 && score.scorePoint % 100 != 0 && isDifficult)
        {
            SpeedEnemy = SpeedEnemy * 10 / 100 + SpeedEnemy;
            tempScore = score.scorePoint;
            isDifficult = false;
        }
        if (score.scorePoint != 0 && score.scorePoint % 100 == 0 && isDifficult)
        {
            SpeedEnemy = tempSpeed;
            tempScore = score.scorePoint;
            isDifficult = false;
        }
    }
}

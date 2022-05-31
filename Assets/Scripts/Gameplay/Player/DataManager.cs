using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public List<int> pointRank; 

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            pointRank.Add(PlayerPrefs.GetInt("point" + i+1, pointRank[i]));
        }
    }

    public void SetTotalCoin(int coin)
    {
        PlayerPrefs.SetInt("coin", coin + PlayerPrefs.GetInt("coin"));
    }

    public void SortingPoint(int point)
    {
        pointRank.Add(point);
        pointRank.Sort();
        pointRank.Reverse();
        SetPointRank();
    }

    void SetPointRank()
    {
        for(int i = 0; i < 5;i++)
        {
            PlayerPrefs.SetInt("point" + i+1, pointRank[i]);
        }  
    }

}

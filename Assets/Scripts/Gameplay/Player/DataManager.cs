using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public List<int> pointRank; 

    private void Start()
    {
        pointRank.Add(PlayerPrefs.GetInt("point1", pointRank[0]));
        pointRank.Add(PlayerPrefs.GetInt("point2", pointRank[1]));
        pointRank.Add(PlayerPrefs.GetInt("point3", pointRank[2]));
        pointRank.Add(PlayerPrefs.GetInt("point4", pointRank[3]));
        pointRank.Add(PlayerPrefs.GetInt("point5", pointRank[4]));
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
        PlayerPrefs.SetInt("point1", pointRank[0]);
        PlayerPrefs.SetInt("point2", pointRank[1]);
        PlayerPrefs.SetInt("point3", pointRank[2]);
        PlayerPrefs.SetInt("point4", pointRank[3]);
        PlayerPrefs.SetInt("point5", pointRank[4]);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardMenu : MonoBehaviour
{
    public TextMeshProUGUI[] scoreText;
    public TextMeshProUGUI[] playerName;

    int[] scoreLeaderboard;
    string[] playerNameLeaderboard;



    void Start()
    {
        LoadLeaderboardData();
    }

    void LoadLeaderboardData()
    {
        for (int i = 0; i < 10; i++)
        {
            scoreText[i].text = scoreLeaderboard[i].ToString();
            playerName[i].text = playerNameLeaderboard[i];
        }
    }
    void SaveLeaderboardData()
    {
        for (int i = 0; i < 10; i++)
        {
            scoreLeaderboard[i] = int.Parse(scoreText[i].text);
            playerNameLeaderboard[i] = playerName[i].text;
        } 
    }
}

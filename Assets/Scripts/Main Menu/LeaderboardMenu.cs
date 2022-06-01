using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardMenu : MonoBehaviour
{
    public TextMeshProUGUI[] scoreText;
    public TextMeshProUGUI[] playerName;

    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            scoreText[i].text = PlayerPrefs.GetInt("score " + i).ToString();
            playerName[i].text = PlayerPrefs.GetString("namePlayer " + i).ToString();
        }
    }
}

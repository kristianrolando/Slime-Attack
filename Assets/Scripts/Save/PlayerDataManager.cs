using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    #region Leaderboard
    int[] scoreLeaderboard;
    string[] playerNameLeaderboard;

    public void GetLeaderboardData()
    {

    }
    public void SetLeaderboardData(int score, string[] playerName)
    {
        for(int i = 0; i < 10; i++)
        {

        }
    }
    #endregion

    #region Skill
    int[] skillEquipped;

    #endregion

    #region Item
    int[] itemEquipped;

    #endregion


}

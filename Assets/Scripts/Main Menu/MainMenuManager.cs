using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject[] othersMenu;
    [SerializeField] GameObject mainMenu;

    void Start()
    {
        CloseOthersMenu();
        //CloseEmptyScoreBar();
    }

    void CloseOthersMenu()
    {
        mainMenu.SetActive(true);

        for (int i = 0; i < othersMenu.Length; i++)
        {
            othersMenu[i].SetActive(false);
        }
    }

    #region Leaderboard
    [SerializeField] GameObject[] barLeaderboard;

    void CloseEmptyScoreBar()
    {
        for(int i = 0; i < barLeaderboard.Length; i++)
        {
            if(PlayerPrefs.HasKey("score " + i))
            {
                barLeaderboard[i].SetActive(true);
            }else if(!PlayerPrefs.HasKey("score " + i))
            {
                barLeaderboard[i].SetActive(false);
            }
            
        }
    }
    #endregion


}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    // list rank
    public List<string> nameRank;
    public List<int> scoreRank;

    // button
    public Color colorDisable, colorEnable;
    public Button continueButton;
    public Image buttonImage;

    public TMP_InputField user_inputField;

    // score
    public PlayerScore score;
    public TextMeshProUGUI finalScore;


    void Start()
    {
        for (int i = 0; i < scoreRank.Count; i++)
        {
            scoreRank[i] = PlayerPrefs.GetInt("score " + i);
            nameRank[i] = PlayerPrefs.GetString("namePlayer " + i);
        }
    }

    private void Update()
    {
        finalScore.text = score.scorePoint.ToString();

        //disabel enable button
        if (user_inputField.text == "")
            DisableButton();
        else
            EnableButton();
    }
    void DisableButton()
    {
        continueButton.enabled = false;
        buttonImage.color = colorDisable;
    }
    void EnableButton()
    {
        continueButton.enabled = true;
        buttonImage.color = colorEnable;
    }

    #region Name Player Rank

    void SetNewName(string name)
    {
        nameRank[10] = name;
    }
    void SaveNameRank()
    {
        for (int i = 0; i < nameRank.Count; i++)
        {
            PlayerPrefs.SetString("namePlayer " + i, nameRank[i]);
        }
    }

    #endregion

    #region Score Player Rank

    void SetNewScore(int score)
    {
        scoreRank[10] = score;
    }
    void SaveScoreRank()
    {
        for (int i = 0; i < scoreRank.Count; i++)
        {
            PlayerPrefs.SetInt("score " + i, scoreRank[i]);
        }
    }
    #endregion
    
    void SortScoreAndName()
    {
        for(int i=0; i< scoreRank.Count;i++)
        {
            for(int j = i+1; j < scoreRank.Count; j++)
            {
                if (scoreRank[i] < scoreRank[j])
                {
                    int tempScore;
                    string tempName;

                    // swap score
                    tempScore = scoreRank[i];
                    scoreRank[i] = scoreRank[j];
                    scoreRank[j] = tempScore;

                    // swap name Player
                    tempName = nameRank[i];
                    nameRank[i] = nameRank[j];
                    nameRank[j] = tempName;
                    Debug.Log("i " + i + "j " + j);
                }
            }
        }
    }

    public void ContinueButton()
    {
        SetNewScore(score.scorePoint);
        SetNewName(user_inputField.text.ToString());
        SortScoreAndName();
        SaveNameRank();
        SaveScoreRank();
        
    }
}

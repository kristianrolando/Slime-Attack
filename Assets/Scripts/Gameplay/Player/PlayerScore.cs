using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [HideInInspector] public int scoreCoin;
    [HideInInspector] public int scorePoint;

    public TextMeshProUGUI pointText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI finalPointText;

    private void Start()
    {
        scoreCoin = 0;
        scorePoint = 0;
    }

    private void Update()
    {
        pointText.text = scorePoint.ToString();
        coinText.text = scoreCoin.ToString();
        finalPointText.text = "" + scorePoint;
    }
    
    public void ScoreIncrement(int value)
    {
        scorePoint += value;
        scoreCoin += value;
    }



}
 
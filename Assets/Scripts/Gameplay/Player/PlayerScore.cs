using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [HideInInspector] public int scoreCoin;
    [HideInInspector] public int scorePoint;

    public Text pointText;
    public Text coinText;
    public Text finalPointText;

    private void Start()
    {
        scoreCoin = 0;
        scorePoint = 0;
    }

    private void Update()
    {
        pointText.text = "" + scorePoint;
        coinText.text = "" + scoreCoin;
        finalPointText.text = "" + scorePoint;
    }
    
    public void ScoreIncrement(int value)
    {
        scorePoint += value;
        scoreCoin += value;
    }



}

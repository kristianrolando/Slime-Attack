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
        scoreCoin = PlayerPrefs.GetInt("coin");
        scorePoint = 0;
    }

    private void Update()
    {
        pointText.text = "" + scorePoint;
        coinText.text = "" + scoreCoin;
        finalPointText.text = "" + scorePoint;
    }
    
    public void scoreIncrement(int value)
    {
        scorePoint = scorePoint + value;
        scoreCoin = scoreCoin + value;
    }



}

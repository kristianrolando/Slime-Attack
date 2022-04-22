using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    // public Text scoreText;

    [HideInInspector] public int score;


    public Text pointText;
    public Text coinText;
    public Text finalScoreText;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        pointText.text = "Point : " + score;
        coinText.text = "Coin : " + score;
        finalScoreText.text = "" + score;
    }
    
    public void scoreIncrement(int point)
    {
        score = score + point;
    }

}

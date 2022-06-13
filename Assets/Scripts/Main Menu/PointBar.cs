using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointBar : MonoBehaviour
{
    public TextMeshProUGUI pointText;

    private void Start()
    {
        pointText.text = "Point : " + PlayerPrefs.GetInt("score 0").ToString();
    }
}

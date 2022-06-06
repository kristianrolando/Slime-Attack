using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public TextMeshProUGUI coin;

    void Update()
    {
        coin.text = PlayerPrefs.GetInt("coin").ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text textCoin;
    [SerializeField] private Text[] textPoint = new Text[5];


    private void Update()
    {
        textCoin.text = PlayerPrefs.GetInt("coin").ToString();
        textPoint[0].text = PlayerPrefs.GetInt("point1").ToString();
        textPoint[1].text = PlayerPrefs.GetInt("point2").ToString();
        textPoint[2].text = PlayerPrefs.GetInt("point3").ToString();
        textPoint[3].text = PlayerPrefs.GetInt("point4").ToString();
        textPoint[4].text = PlayerPrefs.GetInt("point5").ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void QuitFromApp()
    {
        Application.Quit();
    }
    public void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
}

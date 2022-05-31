using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject UISelectionMenu;

    bool isMenuPressed;

    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void QuitFromApp()
    {
        Application.Quit();
    }
    public void MenuSelection()
    {
        if(!isMenuPressed)
        {
            UISelectionMenu.SetActive(false);
            isMenuPressed = true;
        }
        else
        {
            UISelectionMenu.SetActive(true);
            isMenuPressed = false;
        }
    }
}


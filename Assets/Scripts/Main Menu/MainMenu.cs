using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    bool isMenuPressed;

    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void QuitFromApp()
    {
        Application.Quit();
    }

    public Animator animSelectionUI;

    public void MenuSelection()
    {
        if(!isMenuPressed)
        {
            animSelectionUI.SetTrigger("true");
            isMenuPressed = true;
        }
        else
        {
            animSelectionUI.SetTrigger("false");
            isMenuPressed = false;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public EnergySystem energy;
    bool isMenuPressed;
    private void Start()
    {
        PlayerPrefs.SetInt("coin", 500);
    }

    public void StartGame()
    {
        energy.UseEnergy();
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


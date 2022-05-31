using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pausePanel;
    public GameObject cover;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }
    }
    public void Resume()
    {
        pausePanel.SetActive(false);
        cover.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        cover.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

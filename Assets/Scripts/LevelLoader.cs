using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    private void Start()
    {
        //Invoke("LoadLevel", 3f);
        StartCoroutine(LoadLevelDelay("MainMenu", 3f));
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously("MainMenu"));
    }
    IEnumerator LoadLevelDelay(string sceneName, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        //You can then put your code below
        //......your code
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;
        }
    }
    

}

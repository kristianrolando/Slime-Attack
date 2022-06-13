using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            
            Load();
        }
        else
        {
            PlayerPrefs.SetFloat("musicVolume", 1); 
            Load();
        }
    }
    
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

}

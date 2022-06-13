using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class EnergySystem : MonoBehaviour
{
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI timerText;

    public int energyUse = 5;
    public int maxEnergy = 100;
    public int restoreDuration = 36;
    int currentEnergy;
    DateTime nextEnergyTime;
    DateTime lastEnergyTime;
    bool isRestoring;

    private void Update()
    {
        //Debug.Log(currentEnergy);
    }

    void Start()
    {
        if(!PlayerPrefs.HasKey("currentEnergy"))
        {
            PlayerPrefs.SetInt("currentEnergy", maxEnergy);
            Load();
            StartCoroutine(RestoreEnergy());
        }
        else
        {
            Load();
            StartCoroutine(RestoreEnergy());
        }
    }
    public void UseEnergy()
    {
        if(currentEnergy >= energyUse)
        {
            currentEnergy = currentEnergy - energyUse;
            UpdateEnergy();
            if(isRestoring == false)
            {
                if(currentEnergy + energyUse == maxEnergy)
                {
                    nextEnergyTime = AddDuration(DateTime.Now, restoreDuration);
                }
                StartCoroutine(RestoreEnergy());
            }
            SceneManager.LoadScene("GamePlay");
        }
        else
        {
            Debug.Log("energy habis");
        }
    }

    IEnumerator RestoreEnergy()
    {
        UpdateEnergyTimer();
        isRestoring = true;
        
        while(currentEnergy < maxEnergy)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime nextDateTime = nextEnergyTime;
            bool isEnergyAdding = false;
            
            while(currentDateTime > nextDateTime)
            {
                if(currentEnergy < maxEnergy)
                {
                    isEnergyAdding = true;
                    currentEnergy++;
                    UpdateEnergy();
                    DateTime timeToAdd = lastEnergyTime > nextDateTime ? lastEnergyTime : nextDateTime;
                    nextDateTime = AddDuration(timeToAdd, restoreDuration);
                }
                else
                {
                    break;
                }
            }
            
            if(isEnergyAdding == true)
            {
                lastEnergyTime = DateTime.Now;
                nextEnergyTime = nextDateTime;
            }

            UpdateEnergyTimer();
            UpdateEnergy();
            Save();
            yield return null;
        }

        isRestoring = false;

    }
    private DateTime AddDuration(DateTime dateTime, int duration)
    {
        return dateTime.AddSeconds(duration);
        //return dateTime.AddMinutes(duration);
    }

    void UpdateEnergyTimer()
    {
        if(currentEnergy >= maxEnergy)
        {
            timerText.text = "FULL";
            return;
        }
        TimeSpan time = nextEnergyTime - DateTime.Now;
        string timeValue = String.Format("{0:D2}:{1:D1}", time.Minutes, time.Seconds);
        timerText.text = timeValue;
    }
    void UpdateEnergy()
    {
        energyText.text = currentEnergy.ToString() + "/" + maxEnergy.ToString();

    }

    private DateTime StringToDate(string dateTime)
    {
        if(String.IsNullOrEmpty(dateTime))
        {
            return DateTime.Now;
        }
        else
        {
            return DateTime.Parse(dateTime);
        }
    }


    void Load()
    {
        currentEnergy = PlayerPrefs.GetInt("currentEnergy");
        nextEnergyTime = StringToDate(PlayerPrefs.GetString("nextEnergyTime"));
        lastEnergyTime = StringToDate(PlayerPrefs.GetString("lastEnergyTime"));
    }

    void Save()
    {
        PlayerPrefs.SetInt("currentEnergy", currentEnergy);
        PlayerPrefs.SetString("nextEnergyTime", nextEnergyTime.ToString());
        PlayerPrefs.SetString("lastEnergyTime", lastEnergyTime.ToString());
    }


}

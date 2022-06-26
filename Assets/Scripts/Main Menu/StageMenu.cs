using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{

    [SerializeField] Sprite select, selected;
    [SerializeField] Image[] sprite;
    [SerializeField] bool[] isSelected;

    private void Start()
    {
        if(PlayerPrefs.HasKey("stage"))
        {
            LoadStageSelected();
        }
        else
        {
            Select(1);
        }
    }

    public void Select(int i)
    {
        if(!isSelected[i-1])
        {
            for(int j = 0; j < sprite.Length; j++)
            {
                sprite[j].sprite = select;
                isSelected[j] = false;
            }
            sprite[i-1].sprite = selected;
            isSelected[i-1] = true;
            PlayerPrefs.SetInt("stage", i);
        }
    }


    void LoadStageSelected()
    {
        for (int j = 0; j < sprite.Length; j++)
        {
            sprite[j].sprite = select;
            isSelected[j] = false;
            if(j+1 == PlayerPrefs.GetInt("stage"))
            {
                sprite[j].sprite = selected;
                isSelected[j] = true;
            }
        }
    }

}

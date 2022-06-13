using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBar : MonoBehaviour
{
    public Image[] iconImage;
    public Sprite[] iconSkill; // 3
    public Sprite[] iconItem;  // 6

    void Start()
    {
        LoadSkillAndItem();
    }

    void LoadSkillAndItem()
    {
        for (int i = 1; i <= 2; i++)
        {
            if(PlayerPrefs.GetInt("skill " + i) != 0)
            {
                iconImage[i - 1].sprite = iconSkill[PlayerPrefs.GetInt("skill " + i)-1];
            }
            else if(PlayerPrefs.GetInt("skill " + i) == 0)
            {
                iconImage[i - 1].enabled = false;
            }
            if (PlayerPrefs.GetInt("item " + i) != 0)
            {
                iconImage[i + 1].sprite = iconItem[PlayerPrefs.GetInt("item " + i)-1];
            }
            else if (PlayerPrefs.GetInt("item " + i) == 0)
            {
                iconImage[i + 1].enabled = false;
            }
        }
    }

    #region Skill

    public void SkillButton(int index)
    {
        int i =  PlayerPrefs.GetInt("skill " + index);
        switch(i)
        {
            case 1:
                Greed();
                break;
            case 2:
                DoublePunch();
                break;
            case 3:
                Arrow();
                break;
        }
    }

    void Greed()
    {

    }
    void DoublePunch()
    {

    }
    void Arrow()
    {

    }
    #endregion

    #region Item

    public void ItemButton(int index)
    {
        int i = PlayerPrefs.GetInt("skill " + index);
        switch (i)
        {
            case 1:
                
                break;
            case 2:
                
                break;
            case 3:
                
                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;
        }
    }
    
    #endregion
}

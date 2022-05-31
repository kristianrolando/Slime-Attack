using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour
{
    public GameObject popUpMessage;

    public Sprite equipped, equip;
    public bool[] isEquipped;
    public Image[] sprites;

    int maxSkill = 2;
    int capacity;

    public void Equip(int index)
    {
        if(!isEquipped[index])
        {
            if(capacity >= maxSkill)
                Instantiate(popUpMessage, transform.position, Quaternion.identity);
            else if (capacity < maxSkill)
            {
                sprites[index].sprite = equipped;
                isEquipped[index] = true;
                SetSkill(index);
                capacity++;
            }  
        }else if(isEquipped[index])
        {
            sprites[index].sprite = equip;
            isEquipped[index] = false;
            DeleteSkill(index);
            capacity--;
        }
    }
    void SetSkill(int skill)
    {
        for (int i = 0; i < maxSkill; i++)
        {
            if (PlayerPrefs.GetInt("skill " + i+1) == 0)
            {
                PlayerPrefs.SetInt("skill " + i+1, skill);
                break;
            }
        }
    }
    void DeleteSkill(int skill)
    {
        for (int i = 0; i < maxSkill; i++)
        {
            if (i == skill)
            {
                PlayerPrefs.SetInt("skill " + i+1, 0);
                break;
            }
        }
    }
}

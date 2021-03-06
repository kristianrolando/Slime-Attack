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
    private void Start()
    {
        LoadSkill();
    }
    private void Update()
    {
        Locked();
    }

    #region  Equip Skill
    public void Equip(int index)
    {
        if(!isEquipped[index-1])
        {
            if(capacity >= maxSkill)
                Instantiate(popUpMessage, transform.position, Quaternion.identity);
            else if (capacity < maxSkill)
            {
                sprites[index-1].sprite = equipped;
                isEquipped[index-1] = true;
                SetSkill(index);
                capacity++;
            }  
        }else if(isEquipped[index-1])
        {
            sprites[index-1].sprite = equip;
            isEquipped[index-1] = false;
            DeleteSkill(index);
            capacity--;
        }
    }
    void SetSkill(int skill)
    {
        for (int i = 1; i <= maxSkill; i++)
        {
            if (PlayerPrefs.GetInt("skill " + i) == 0)
            {
                PlayerPrefs.SetInt("skill " + i, skill);
                break;
            }
        }
    }
    void DeleteSkill(int skill)
    {
        for (int i = 1; i <= maxSkill; i++)
        {
            if (i == skill)
            {
                PlayerPrefs.SetInt("skill " + i, 0);
                break;
            }
        }
    }
    #endregion

    #region Locked
    public GameObject[] lockSkill;

    void Locked()
    {
        for (int i = 1; i < 3; i++)
        {
            if (PlayerPrefs.GetInt("m_skill " + i) != 0)
                lockSkill[PlayerPrefs.GetInt("m_skill " + i) - 1].SetActive(false);
            if (PlayerPrefs.GetInt("m_skill " + i) == 0)
                lockSkill[i - 1].SetActive(true);
        }
    }

    void LoadSkill()
    {
        for (int i = 1; i < 3; i++)
        {
            if (PlayerPrefs.GetInt("skill " + i) != 0 )
            {
                isEquipped[PlayerPrefs.GetInt("skill " + i) - 1] = true;
                sprites[PlayerPrefs.GetInt("skill " + i) - 1].sprite = equipped;
                capacity++;
            }
        }
    }
    #endregion
}

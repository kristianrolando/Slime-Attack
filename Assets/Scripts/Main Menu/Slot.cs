using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int indexSkill;

    SkillMenu skillMenu;

    private void Start()
    {
        skillMenu = GameObject.Find("Skill Menu").GetComponent<SkillMenu>();
    }

    public void EquipButton()
    {
        if (gameObject.tag == "Equip")
        {
            if (skillMenu.slotCapacity < skillMenu.maxSkill)
            {
                SetSkill(indexSkill); // memasukan value skill yg di equip
                skillMenu.isEquipped[indexSkill-1] = true;
                skillMenu.slotCapacity++;
                gameObject.tag = "Equipped" ;
            }
        }
        else if (gameObject.tag == "Equipped")
        {
            DeleteSkill(skillMenu.slotCapacity);
            skillMenu.isEquipped[indexSkill - 1] = false;
            skillMenu.slotCapacity--;
            gameObject.tag = "Equip";
        }
    }
    void SetSkill(int skill)
    {
        if (PlayerPrefs.GetInt("skill 1") == 0)
            PlayerPrefs.SetInt("skill 1", skill);
        else if (PlayerPrefs.GetInt("skill 2") == 0)
            PlayerPrefs.SetInt("skill 2", skill);
        else if (PlayerPrefs.GetInt("skill 3") == 0)
            PlayerPrefs.SetInt("skill 3", skill);
        else if (PlayerPrefs.GetInt("skill 4") == 0)
            PlayerPrefs.SetInt("skill 4", skill);
    }
    void DeleteSkill(int skill)
    {
        switch (skill)
        {
            case 1:
                PlayerPrefs.DeleteKey("skill 1");
                break;
            case 2:
                PlayerPrefs.DeleteKey("skill 2");
                break;
            case 3:
                PlayerPrefs.DeleteKey("skill 3");
                break;
            case 4:
                PlayerPrefs.DeleteKey("skill 4");
                break;
        }
    }
}

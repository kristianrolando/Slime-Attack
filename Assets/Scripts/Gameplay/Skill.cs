using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Used in every Button Skill
public class Skill : MonoBehaviour
{
    public int slotIndex;

    public Image image;
    SkillGameplay skillPanel;

    private void Start()
    {
        skillPanel = GameObject.Find("Skill Panel").GetComponent<SkillGameplay>();
        image.sprite = skillPanel.spriteSkill[PlayerPrefs.GetInt("skill " + slotIndex)];
        //SetDataSkill();
    }

    void SetDataSkill()
    {
        switch(slotIndex)
        {
            case 1:
                image.sprite = skillPanel.spriteSkill[PlayerPrefs.GetInt("skill 1")];
                break;
            case 2:
                image.sprite = skillPanel.spriteSkill[PlayerPrefs.GetInt("skill 2")];
                break;
            case 3:
                image.sprite = skillPanel.spriteSkill[PlayerPrefs.GetInt("skill 3")];
                break;
            case 4:
                image.sprite = skillPanel.spriteSkill[PlayerPrefs.GetInt("skill 4")];
                break;

        }
    }
}
                      
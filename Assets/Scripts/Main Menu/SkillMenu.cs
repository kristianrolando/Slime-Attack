using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour
{
    public bool[] isEquipped = new bool[4];
    public Text[] statusSkill = new Text[4];
    public int maxSkill = 4; // max skill got carried

    [HideInInspector] public int slotCapacity = 0;
    private void Start()
    {
        ReturnDataSkill();
    }

    private void Update()
    {
        // false
        if(!isEquipped[0])
        {
            statusSkill[0].text = "Equip";
        }
        if (!isEquipped[1])
        {
            statusSkill[1].text = "Equip";
        }
        if (!isEquipped[2])
        {
            statusSkill[2].text = "Equip";
        }
        if (!isEquipped[3])
        {
            statusSkill[3].text = "Equip";
        }

        // true
        if (isEquipped[0])
        {
            statusSkill[0].text = "Equipped";
        }
        if (isEquipped[1])
        {
            statusSkill[1].text = "Equipped";
        }
        if (isEquipped[2])
        {
            statusSkill[2].text = "Equipped";
        }
        if (isEquipped[3])
        {
            statusSkill[3].text = "Equipped";
        }
    }

    void ReturnDataSkill()
    {
        if(PlayerPrefs.GetInt("skill 1") != 0)
            isEquipped[PlayerPrefs.GetInt("skill 1") - 1] = true;
        if(PlayerPrefs.GetInt("skill 2") != 0)
            isEquipped[PlayerPrefs.GetInt("skill 2") - 1] = true;
        if (PlayerPrefs.GetInt("skill 3") != 0)
            isEquipped[PlayerPrefs.GetInt("skill 3") - 1] = true;
        if (PlayerPrefs.GetInt("skill 4") != 0)
            isEquipped[PlayerPrefs.GetInt("skill 4") - 1] = true;
    }
}

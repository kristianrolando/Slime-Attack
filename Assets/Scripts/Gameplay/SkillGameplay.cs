using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// used in Skill Panel
public class SkillGameplay : MonoBehaviour
{
    public Sprite[] spriteSkill; // penempatan sesuai index skill
    public GameObject[] skillObject;



    private void Start()
    {
        for(int i =1; i< 5; i++)
        {
            if (PlayerPrefs.GetInt("skill " + i) == 0)
                skillObject[i - 1].SetActive(false);
        }
    }

    public void Skill1()
    {
        // efek skill 1
    }
    public void Skill2()
    {

    }

}

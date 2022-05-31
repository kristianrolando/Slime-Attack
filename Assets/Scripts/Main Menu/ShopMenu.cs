﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public Color color1,color2;
    public Image skill, item, energy;
    private void Start()
    {
        ChangeColorSkill();
    }

    public void ChangeColorSkill()
    {
        skill.color = color1;
        item.color = color2;
        energy.color = color2;
    }
    public void ChangeColorItem()
    {
        item.color = color1;
        energy.color = color2;
        skill.color = color2;
    }
    public void ChangeColorEnergy()
    {
        energy.color = color1;
        skill.color = color2;
        item.color = color2;
    }
}
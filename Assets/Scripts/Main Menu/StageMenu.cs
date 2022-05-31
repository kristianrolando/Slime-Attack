using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{
    public Sprite select;
    public Sprite selected;
    public Image[] sprite;

    public bool[] isSelected;

    public void Select(int i)
    {
        if(!isSelected[i])
        {
            sprite[i].sprite = selected;
            isSelected[i] = true;
        }
        else
        {
            sprite[i].sprite = select;
            isSelected[i] = false;
        }
    }

}

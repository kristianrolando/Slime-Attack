using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public Color color1, color2;
    public Image skill, item, energy;
    private void Start()
    {
        ChangeColorSkill();
    }
    private void Update()
    {
        LockBought();
    }

    public GameObject[] lockSkill;
    public GameObject[] lockItem;

    void LockBought()
    {
        for (int i = 1; i <= 3; i++)
        {
            if (PlayerPrefs.GetInt("m_skill " + i) != 0)
                lockSkill[PlayerPrefs.GetInt("m_skill " + i) - 1].SetActive(true);
            if (PlayerPrefs.GetInt("m_skill " + i) == 0)
                lockSkill[i - 1].SetActive(false);
        }
        for (int i = 1; i <= 6; i++)
        {
            if (PlayerPrefs.GetInt("m_item " + i) != 0)
                lockItem[PlayerPrefs.GetInt("m_item " + i) - 1].SetActive(true);
            if (PlayerPrefs.GetInt("m_item " + i) == 0)
                lockItem[i - 1].SetActive(false);
        }
    }

    #region Category Button
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
    #endregion

    #region Details Text
    public TextMeshProUGUI textDetails;

    public void Details(string description)
    {
        textDetails.text = description;
    }
    #endregion

    #region Buy

    int IDItem;
    int IDSkill;
    int IDEnergy;

    public void SelectSkill(int index)
    {
        IDSkill = index;
        IDItem = 0;
        IDEnergy = 0;
    }
    public void SelectItem(int index)
    {
        IDItem = index;
        IDSkill = 0;
        IDEnergy = 0;
    }
    public void SelectEnergy(int index)
    {
        IDEnergy = index;
        IDSkill = 0;
        IDItem = 0;
    }
    int coin;
    public void CoinSpent(int coin)
    {
        this.coin = coin;
    }

    public void BuyButton()
    {
        if (IDSkill != 0)
        {
            for (int i = 1; i <= 3 ; i++)
            {
                if(IDSkill == i)
                {
                    if(PlayerPrefs.GetInt("m_skill " + IDSkill) != i)
                    {
                        if (coin > PlayerPrefs.GetInt("coin"))
                        {
                            Debug.Log("coin tidak cukup");
                        }
                        else
                        {
                            // set coin amount
                            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - coin);
                            PlayerPrefs.SetInt("m_skill " + IDSkill, IDSkill);
                        }
                    }
                }
            }
        }
        if (IDItem != 0)
        {
            for (int i = 1; i <= 6; i++)
            {
                if (IDItem == i)
                {
                    if (PlayerPrefs.GetInt("m_item " + IDItem) != i)
                    {
                        if (coin > PlayerPrefs.GetInt("coin"))
                        {
                            Debug.Log("coin tidak cukup");
                        }
                        else
                        {
                            // set coin amount
                            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - coin);
                            PlayerPrefs.SetInt("m_item " + IDItem, IDItem);
                        }
                    }
                }
            }
        }



        /*
        if (coin > PlayerPrefs.GetInt("coin"))
        {
            Debug.Log("coin tidak cukup");
        }
        else
        {
            // set coin amount
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - coin);
            // set stuff bought
            #region stuff bought
            if (IDSkill != 0)
            {
                PlayerPrefs.SetInt("m_skill " + IDSkill, IDSkill);
            }
            else if (IDItem != 0)
            {
                PlayerPrefs.SetInt("m_item " + IDItem, IDItem);
            }
            else if (IDEnergy != 0)
            {

            }
            #endregion

        }
        */
    }

    #endregion
}

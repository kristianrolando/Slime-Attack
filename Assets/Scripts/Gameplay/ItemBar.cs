using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBar : MonoBehaviour
{
    public Image[] iconImage;
    public Sprite[] iconSkill; // 3
    public Sprite[] iconItem;  // 6
    public GameObject[] lockItemBar;

    [HideInInspector] public PlayerHealth health;
    [HideInInspector] public PlayerScore score;
    [HideInInspector] public PlayerAttack attack;
    [HideInInspector] public GameManager gm;

    private void Awake()
    {
        health = GameObject.Find("Player").GetComponent<PlayerHealth>();
        score = GameObject.Find("Player").GetComponent<PlayerScore>();
        gm = GameObject.Find("Player").GetComponent<GameManager>();
        attack = GameObject.Find("Player").GetComponent<PlayerAttack>();
    }

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

    [HideInInspector] public bool isSkill;
    [HideInInspector] public bool isSkillGreed;

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
        }
        //PlayerPrefs.SetInt("skill " + index, 0);
        //PlayerPrefs.SetInt("m_skill " + index, 0);
        lockItemBar[index - 1].SetActive(true);
    }

    public GameObject greedObject;
    public void Greed()
    {
        gm.SpeedEnemy = 7f;
        greedObject.SetActive(true);
        health.isGreed = true;
        attack.SkillGreedAnim();
        Invoke("StopGreed", 20f);
    }
    void StopGreed()
    {
        health.isGreed = false;
        gm.SpeedEnemy = gm.tempSpeed;
        greedObject.SetActive(false);
    }
    void DoublePunch()
    {
        attack.DoublePunch();
    }
    #endregion

    #region Item
    /*
     * 1. Health Potion : +20% panjang health bar
     * 2. Score 2x
     * 3. Score 3x
     * 4. Defense deff +30%
     * 5. Attack deff +20%
     * 
    */

    public void ItemButton(int index)
    {
        if (PlayerPrefs.GetInt("item " + index) != 0)
        {
            int i = PlayerPrefs.GetInt("item " + index);
            switch (i)
            {
                case 1:
                    HealthPotion(index);
                    break;
                case 2:
                    ScorePotion(2);
                    break;
                case 3:
                    ScorePotion(5);
                    break;
                case 4:
                    DefensePotion();
                    break;
                case 5:
                    AttackPotion();
                    break;
            }
            PlayerPrefs.SetInt("item " + index, 0);
            PlayerPrefs.SetInt("m_item " + i, 0);
            lockItemBar[index + 1].SetActive(true);
        }
        
    }
    public RectTransform rt;
    
    void HealthPotion(int index)
    {
        health.maxHealth = 150;
        health.currentHealth = 150;
        rt.sizeDelta = new Vector2(660, 62);
    }

    void ScorePotion(int point)
    {
        score.pointAdd = point;
    }
    void DefensePotion()
    {
        health.defense += 5;
    }
    void AttackPotion()
    {
        health.defense += 3;
    }

    #endregion
}

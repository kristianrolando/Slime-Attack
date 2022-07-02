using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EquipmentMenu : MonoBehaviour
{
    // sesi 1
    [SerializeField] bool[] isEquipped;
    [SerializeField] Image[] imageEquipButton;
    [SerializeField] Sprite equip, equipped;

    [SerializeField] GameObject popUpMessage;

    [SerializeField] int maxItem = 2;

    // sesi 2
    [SerializeField] Image[] iconImage;
    [SerializeField] Sprite[] itemIcon;
    [SerializeField] GameObject[] xButton; 

    private void Start()
    {
        LoadItemEquipped();
    }
    private void Update()
    {
        Locked();
    }

    #region Details
    public TextMeshProUGUI detailsText;
    public GameObject popUpDetails;

    public void Details(string description)
    {
        popUpDetails.SetActive(true);
        detailsText.text = description;
    }
    public void DismissDetailsPanel()
    {
        popUpDetails.SetActive(false);
    }
    #endregion

    #region Equip and UnEquip

    public void EquipButton(int index)
    {
        if(!isEquipped[index - 1])
        {
            if(PlayerPrefs.GetInt("item 1") != 0 && PlayerPrefs.GetInt("item 2") != 0)
                Instantiate(popUpMessage, transform.position, Quaternion.identity);
            else
            {
                Equip(index, true);
            }
                
        }else if(isEquipped[index - 1])
        {
            Equip(index, false);
        }
    }    

    void Equip(int index, bool isEquipped)
    {
        if(isEquipped)
        {
            this.isEquipped[index - 1] = true;
            imageEquipButton[index - 1].sprite = equipped;
            if(PlayerPrefs.GetInt("item 1") == 0)
            {
                ChangeIconImage(0, index, true);
            }else if(PlayerPrefs.GetInt("item 2") == 0 && PlayerPrefs.GetInt("item 1") != 0)
            {
                ChangeIconImage(1, index, true);
            }
            SetAndDeleteItem(index, true);
        }
        else
        {
            this.isEquipped[index - 1] = false;
            imageEquipButton[index - 1].sprite = equip;
            if(PlayerPrefs.GetInt("item 1") == index)
            {
                ChangeIconImage(0, index, false);
            }
            else if(PlayerPrefs.GetInt("item 2") == index)
            {
                ChangeIconImage(1, index, false);
            }
            SetAndDeleteItem(index, false);
        }
    }
    void ChangeIconImage(int indexIcon, int indexItem, bool isSet)
    { 
        if(isSet)
        {
            iconImage[indexIcon].enabled = true;
            iconImage[indexIcon].sprite = itemIcon[indexItem-1];
        }
        else if (!isSet)
        {
            iconImage[indexIcon].enabled = false;
        }
    }

    void SetAndDeleteItem(int item, bool isSet)
    {
        for (int i = 0; i < maxItem; i++)
        {
            if(isSet)
            {
                // set / save
                int f = i + 1;
                if (PlayerPrefs.GetInt("item " + f) == 0)
                {
                    xButton[i].SetActive(true);
                    PlayerPrefs.SetInt("item " + f, item);
                    break;
                }
            }
            else
            {
                // delete
                int f = i + 1;
                if (PlayerPrefs.GetInt("item " + f) == item)
                {
                    xButton[i].SetActive(false);
                    PlayerPrefs.SetInt("item " + f, 0);
                    break;
                }
            }
        }
    }

    public void DismissButton(int index)
    {
        EquipButton(PlayerPrefs.GetInt("item " + index));
    }
    public void DismissButtonIcon(Image image)
    {
        image.enabled = false;
    }

    void LoadItemEquipped()
    {
        for (int i = 0; i < maxItem; i++)
        {
            int f = i + 1;
            if (PlayerPrefs.GetInt("item " + f) != 0)
            {
                // sesi 1 
                isEquipped[PlayerPrefs.GetInt("item " + f) - 1] = true;
                imageEquipButton[PlayerPrefs.GetInt("item " + f) - 1].sprite = equipped;

                //sesi 2
                iconImage[i].enabled = true;
                iconImage[i].sprite = itemIcon[PlayerPrefs.GetInt("item " + f) - 1];
                xButton[i].SetActive(true);
            }
            else if(PlayerPrefs.GetInt("item " + f) == 0)
            {
                iconImage[i].enabled = false;
                isEquipped[i] = false;
                imageEquipButton[i].sprite = equip;
                xButton[i].SetActive(false);
            }

        }
    }
    #endregion

    #region Locked
    public GameObject[] lockItem;

    void Locked()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (PlayerPrefs.GetInt("m_item " + i) != 0)
                lockItem[PlayerPrefs.GetInt("m_item " + i) - 1].SetActive(false);
            if (PlayerPrefs.GetInt("m_item " + i) == 0)
                lockItem[i - 1].SetActive(true);
        }
    }

    #endregion

}

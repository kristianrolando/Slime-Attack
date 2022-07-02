using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteData : MonoBehaviour
{
    public void DeleteAll(int coin)
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("coin", coin);
    }
}

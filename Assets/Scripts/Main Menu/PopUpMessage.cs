using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessage : MonoBehaviour
{
    GameObject popUpParent;

    private void Start()
    {
        popUpParent = GameObject.Find("Pop Up");
        transform.SetParent(popUpParent.gameObject.transform);
        Invoke(nameof(SelfDestruct), 3f);
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}

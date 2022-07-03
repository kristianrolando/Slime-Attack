using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyObject : MonoBehaviour
{
    private void Start()
    {
        Invoke("DelayDestroy", 4f);
    }
    void DelayDestroy()
    {
        Destroy(gameObject);
    }
}

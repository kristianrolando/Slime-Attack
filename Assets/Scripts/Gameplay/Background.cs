using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    SpriteRenderer spriteBackground;

    [SerializeField] Sprite[] backgroundImage;

    private void Awake()
    {
        spriteBackground = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        spriteBackground.sprite = backgroundImage[PlayerPrefs.GetInt("stage") - 1];
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSkillGreed : MonoBehaviour
{
    [HideInInspector] public PlayerScore score;
    private void Awake()
    {
        score = GameObject.Find("Player").GetComponent<PlayerScore>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (collision.gameObject.tag == "Magma Rock")
                score.ScoreIncrement(3);
            else
                score.ScoreIncrement(1);
        }
    }
}

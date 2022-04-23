using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 2.5f;
    GameObject target;
    PlayerScore score;
    PlayerHealth health;
    Vector2 direction;

    public int maxLifeWood = 1;
    public int currentlyLifeWood;
    public int maxLifeRock = 1;
    public int currentlyLifeRock;
    public int maxLifeMagmaRock = 1;
    public int currentlyLifeMagmaRock;
    public int maxLifeHearth = 1;
    public int currentlyLifeHeart;

    // bool isSlow;
    // [Range(0.01f,1f)] public float slowTime = 0.3f;
    private void Start()
    {
        target = GameObject.Find("Player");
        score = GameObject.Find("Player").GetComponent<PlayerScore>();
        health = GameObject.Find("Player").GetComponent<PlayerHealth>();
        direction = target.transform.position + new Vector3(0f, 0.5f, 0f);

        currentlyLifeWood = maxLifeWood;
        currentlyLifeRock = maxLifeRock;
        currentlyLifeMagmaRock = maxLifeMagmaRock;
        currentlyLifeHeart = maxLifeHearth;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
    }
    public void GotDamage()
    {
        if(gameObject.tag == "Wood")
        {
            currentlyLifeWood -= 1;
            if (currentlyLifeWood <= 0)
            {
                score.scoreIncrement(1);
                SelfDestruct();
            }
        }
        else if(gameObject.tag == "Rock")
        {
            currentlyLifeRock -= 1;
            if (currentlyLifeRock <= 0)
            {
                score.scoreIncrement(1);
                SelfDestruct();
            }
        }
        else if(gameObject.tag == "Magma Rock")
        {
            currentlyLifeMagmaRock -= 1;
            if (currentlyLifeMagmaRock <= 0)
            {
                score.scoreIncrement(3);
                SelfDestruct();
            }
        }
        else if(gameObject.tag == "Heart")
        {
            currentlyLifeHeart -= 1;
            if (currentlyLifeHeart <= 0)
            {
                health.healthRecovery();
                SelfDestruct();
            }
        }
    }
   
    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.tag == "Terrain")
        {
            SelfDestruct();
        }
    }
}

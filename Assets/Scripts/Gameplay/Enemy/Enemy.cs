using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 3f;
    GameObject target;
    PlayerScore score;
    PlayerHealth health;
    Vector2 direction;

    public int maxLifeWood = 1;
    int currentlyLifeWood;
    public int maxLifeRock = 1;
    int currentlyLifeRock;
    public int maxLifeMagmaRock = 3;
    int currentlyLifeMagmaRock;
    public int maxLifeHearth = 1;
    int currentlyLifeHeart;


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
        transform.Rotate(0, 0, 360 * 1 * Time.deltaTime);

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
            else if (currentlyLifeHeart < maxLifeMagmaRock)
            {
                Time.timeScale = 0.3f;
                Invoke("SlowDown", 2f);
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

    void SlowDown()
    {
        Time.timeScale = 1f;
    }

    public void SelfDestruct()
    {
        if (gameObject.tag == "Magma Rock")
            Time.timeScale = 1f;
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

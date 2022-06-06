using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int maxHealth = 100;
    [SerializeField] int damageWood = 10;
    [SerializeField] int damageRock = 25;
    [SerializeField] int damageMagmaRock = 35;
    [SerializeField] int healthRecover = 40;

    public HealthBar healthBar;
    public GameObject gameOver;
    public GameObject cover;

    bool isDie;
    int currentHealth;
    Animator anim;
    PlayerScore coin;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
        coin = GetComponent<PlayerScore>();
        isDie = false;

    }
    private void Update()
    {
        // decrease health
        if (currentHealth >=  maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentHealth <=0 && !isDie)
        {
            // die
            anim.SetTrigger("death");

            gameOver.SetActive(true);
            cover.SetActive(true);
            coin.SaveCoin();
            Time.timeScale = 0f;
            isDie = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wood")
        {
            TakeDamage(damageWood);
            anim.SetTrigger("hurt");
        }
        else if (collision.gameObject.tag == "Rock")
        {
            TakeDamage(damageRock);
            anim.SetTrigger("hurt");
        }
        else if (collision.gameObject.tag == "Magma Rock")
        {
            TakeDamage(damageMagmaRock);
            anim.SetTrigger("hurt");
        }
        else if (collision.gameObject.tag == "Heart")
            healthRecovery();
    }
    public void healthRecovery()
    {
        // called when player attack heart
        currentHealth += healthRecover;
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}

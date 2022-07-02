using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    [SerializeField] int damageWood = 15;
    [SerializeField] int damageRock = 30;
    [SerializeField] int damageMagmaRock = 40;
    [SerializeField] int healthRecover = 30;

    public int defense = 20;
    [HideInInspector] public int tempDef;

    public HealthBar healthBar;
    public GameObject gameOver;
    public GameObject cover;

    bool isDie;
    [HideInInspector] public int currentHealth;
    Animator anim;
    PlayerScore coin;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
        coin = GetComponent<PlayerScore>();
        isDie = false;
        tempDef = defense;

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
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wood")
        {
            TakeDamage(damageWood);
            //anim.SetTrigger("hurt");
        }
        else if (collision.gameObject.tag == "Rock")
        {
            TakeDamage(damageRock);
            //anim.SetTrigger("hurt");
        }
        else if (collision.gameObject.tag == "Magma Rock")
        {
            TakeDamage(damageMagmaRock);
            //anim.SetTrigger("hurt");
        }
        else if (collision.gameObject.tag == "Heart")
            HealthRecovery();
    }
    public void HealthRecovery()
    {
        // called when player attack heart
        currentHealth += healthRecover;
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage + defense;
        healthBar.SetHealth(currentHealth);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int damageWood = 10;
    [SerializeField] private int damageRock = 25;
    [SerializeField] private int damageMagmaRock = 35;
    [SerializeField] private int healthRecover = 40;

    public HealthBar healthBar;
    public GameObject gameOver;

    int currentHealth;
    Animator anim;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(currentHealth >=  maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentHealth <=0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wood" )
        {
            
            TakeDamage(damageWood);
            anim.SetTrigger("hurt");
        }else if (collision.gameObject.tag == "Rock" )
        {
            TakeDamage(damageRock);
            anim.SetTrigger("hurt");
        }
        else if(collision.gameObject.tag == "Magma Rock")
        {
            TakeDamage(damageMagmaRock);
            anim.SetTrigger("hurt");
        }
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
        if (currentHealth == 0)
        {
            anim.SetTrigger("death");
            // menu die;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

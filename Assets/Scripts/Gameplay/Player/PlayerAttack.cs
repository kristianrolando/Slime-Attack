using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{   
    [SerializeField] Transform attackPosRight;
    [SerializeField] Transform attackPosLeft;

    [SerializeField] float attackRangeRight;
    [SerializeField] float attackRangeLeft;
    [SerializeField] LayerMask isEnemies;

    [HideInInspector] public bool statEnimiesRight, statEnimiesLeft;

    [SerializeField] AudioSource attSound;
    [SerializeField] AudioSource greedSound;
    [SerializeField] AudioSource doublePunchSound;

    [SerializeField] GameObject tutorial;

    Animator anim;
    SpriteRenderer sprite;

    float time;
    [SerializeField] float timeBetweenAttack = 0.3f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        tutorial.SetActive(true);
        Time.timeScale = 1f;
    }

    void Update()
    {
        DetectionEnemies();
        Attack();
        if(DoublePunchSkill)
        {
            AttackLeft();
            AttackRight();
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tutorial.SetActive(false);
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (position.x < 0)
                AttackLeft();
            else
                AttackRight();
        }
        /*
        if (time <= 0)
        { 
            /*if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;
                if (touchPosition.x < 0)
                    AttackLeft();
                else
                    AttackRight();
                attSound.Play();
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;
                
                if(touch.phase == TouchPhase.Ended)
                {
                    if (touchPosition.x < 0)
                        AttackLeft();
                    else
                        AttackRight();
                    attSound.Play();
                }
                
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("touch");
                Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (position.x < 0)
                    AttackLeft();
                else
                    AttackRight();
            }
            time = timeBetweenAttack;
        }
        else
        {
            time -= Time.deltaTime;
        } */
    }


    void DetectionEnemies()
    {
        Collider2D[] enemiesRight = Physics2D.OverlapCircleAll(attackPosRight.position, attackRangeRight, isEnemies);
        if (enemiesRight.Length > 0)
            statEnimiesRight = true;
        else
            statEnimiesRight = false;

        Collider2D[] enemiesLeft = Physics2D.OverlapCircleAll(attackPosLeft.position, attackRangeLeft, isEnemies);
        if (enemiesLeft.Length > 0)
            statEnimiesLeft = true;
        else
            statEnimiesLeft = false;
    }

    public void AttackRight()
    {
        Collider2D[] enemiesToDamageRight = Physics2D.OverlapCircleAll(attackPosRight.position, attackRangeRight, isEnemies);
        for (int i = 0; i < enemiesToDamageRight.Length; i++)
        {
            anim.SetTrigger("punch");
            sprite.flipX = false;
            enemiesToDamageRight[i].GetComponent<Enemy>().GotDamage();
            attSound.Play();
        }
    }

    public void AttackLeft()
    {
        Collider2D[] enemiesToDamageLeft = Physics2D.OverlapCircleAll(attackPosLeft.position, attackRangeLeft, isEnemies);
        for (int i = 0; i < enemiesToDamageLeft.Length; i++)
        {
            anim.SetTrigger("punch");
            sprite.flipX = true;
            enemiesToDamageLeft[i].GetComponent<Enemy>().GotDamage();
            attSound.Play();
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosRight.position, attackRangeRight);
        Gizmos.DrawWireSphere(attackPosLeft.position, attackRangeLeft);
    }

    public void SkillGreedAnim()
    {
        anim.SetTrigger("greed");
        greedSound.Play();
    }
    bool DoublePunchSkill;
    public void DoublePunch()
    {
        anim.SetTrigger("doublepunch");
        DoublePunchSkill = true;
        doublePunchSound.Play();
        Invoke("StopDoublePunch", 5f);
    }
    void StopDoublePunch()
    {
        DoublePunchSkill = false;  
    }
}

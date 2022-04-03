using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    bool areWeStarted = false;

    public int extraJumpsValue;
    public int coins;
    public int hasFlower = 0;
    private float timeBtwAttack;
    public float startTimeBtwAttack;



    public Transform attackPos;
    public float attackRangeX;
    public float attackRangeY;
    public LayerMask whatIsEnemies;
    public Animator playerAnim;


    public int damage;

    int j = 1;

    public float knockbackX = 20F;
    public float knockbackY = 1F;
    public bool attaciking;

    public int health = 5;
    public int maxHealth = 5;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Awake()
    {
        extraJumpsValue = PlayerPrefs.GetInt("extraJumpsValue");
        coins = PlayerPrefs.GetInt("CurrentCoins");
        health = PlayerPrefs.GetInt("Health",5);
    }

    void Start()
    {
        areWeStarted = false;
        extraJumpsValue = PlayerPrefs.GetInt("extraJumpsValue");
        coins = PlayerPrefs.GetInt("CurrentCoins");
        health = PlayerPrefs.GetInt("Health", 5);
        areWeStarted = true;
    }

    void Update()
    {
        if (!areWeStarted) return; 
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (!Input.GetKey(KeyCode.F))
        {
            attaciking = false;
        }
        if (attaciking == false)
        {
            j = 1;
        }
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.F))
            {

                attaciking = true;

                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                if (j == 1)
                {
                    playerAnim.SetTrigger("Attack1");

                    j++;

                }
                else if (j == 2)
                {

                    playerAnim.SetTrigger("Attack2");
                    j++;
                }
                else if (j == 3)
                {

                    playerAnim.SetTrigger("Attack3");
                    j = 1;

                }

            }
            timeBtwAttack = startTimeBtwAttack;


        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Debug.Log(health);
            Debug.Log(maxHealth);

            SceneManager.LoadScene("GameOver");
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }

    public void Damaged()
    {
        health -= 1;

        PlayerPrefs.SetInt("Health", health);

        if (health < maxHealth)
        {
            maxHealth = health;
        }
    }
}
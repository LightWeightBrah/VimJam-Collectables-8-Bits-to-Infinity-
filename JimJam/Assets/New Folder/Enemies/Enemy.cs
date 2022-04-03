using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private Animator anim;
    public GameObject particleEffect;
    public float dazedTime;
    public float startDazedTime;


    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
    }
    void Update()
    {
        //Debug.Log(health);
        if (dazedTime <= 0)
        {
            speed = speed;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
       // dazedTime = startDazedTime;
       // Instantiate(particleEffect, transform.position, Quaternion.identity);
        health -= damage;

    }
}


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int health = 100;
    int currentHealth;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;
    private float timeBtwShots;
    public float starTimeBtwShots;
    public GameObject proyectile;
    [SerializeField]
    private float range;
    bool StayFollow = false;
    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = starTimeBtwShots;
    }
    void Update()
    {
        if(Vector3.Distance(player.position,transform.position)<=range)
        {
            StayFollow = true;                      
        }        
        if (StayFollow == true)
        {
            FollowPlayer();
        }


    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Animacion de Muerte

        if(currentHealth<=0)
        {
            Die();
        }

    }
    void Die()
    {
        Debug.Log("Murio el Enemigo");
    }
    public void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = this.transform.position;
        }
         if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        if (timeBtwShots <= 0)
        {
            Instantiate(proyectile, transform.position, Quaternion.identity);
            timeBtwShots = starTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            health -= 10;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


}

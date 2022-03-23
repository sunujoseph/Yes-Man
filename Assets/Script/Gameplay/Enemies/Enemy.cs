using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    Rigidbody2D _rb;


    public float enemyHealth = 10.0f;
    float maxHealth = 10.0f;

    public float speed;
    public float lineOfSite;

     Vector3 direction;



    private void Start()
    {
        ResetHeal();
        _rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        direction = player.transform.position - transform.position;

      
    }

    private void FixedUpdate()
    {
        LookTowardPlayer();
        MoveTowardPlayer();
    }

    public virtual void MoveTowardPlayer()
    {
        float distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);


        if (distanceFromPlayer < lineOfSite)
        {
            _rb.MovePosition((Vector3)transform.position + (direction * speed * Time.deltaTime));
        }
    }

    public virtual void LookTowardPlayer()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
        direction.Normalize();

    }

    void ResetHeal()
    {
        enemyHealth = maxHealth;
    }

    public void DealDamage(float damage)
    {
        enemyHealth -= damage;
        CheckDeath();

    }
    private void CheckOverHeal()
    {
        if (enemyHealth > maxHealth)
        {
            enemyHealth = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
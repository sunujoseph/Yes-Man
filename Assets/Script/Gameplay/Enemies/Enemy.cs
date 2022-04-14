using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Transform player;
    Rigidbody2D _rb;

    public float damage = 2.0f;

    public float enemyHealth;
    [SerializeField] float maxHealth = 10.0f;

    public float speed;
    public float lineOfSite;

    [HideInInspector] public Vector3 direction;
    //number of enemies that have been killed
    public int enemyDeathCounter = 0;

    public Transform deathEffect, deathEffect2, deathEffect3;


    public float itemDropPercent = 75.0f;
    public List<GameObject> itemsToDrop = new List<GameObject>();


    private void Start()
    {
        ResetHeal();
        _rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        if (enemyHealth > 0 && player != null)
        {
            direction = player.transform.position - transform.position;
        }

        CheckDeathCount();
        CheckOverHeal();


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
        _rb.rotation = angle + 90;
        
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
            var boom = Instantiate(deathEffect, transform.position, transform.rotation);
            var boom2 = Instantiate(deathEffect2, transform.position, transform.rotation);
            var boom3 = Instantiate(deathEffect3, transform.position, transform.rotation);
            
            Destroy(boom.gameObject, 1);
            Destroy(boom2.gameObject, 2);
            Destroy(boom3.gameObject, 3);

            DropLoot();
            enemyDeathCounter +=1 ;
            Destroy(gameObject);
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //Do contact damage to player
            PlayerControl player = collision.gameObject.GetComponent<PlayerControl>();
            player.TakeDamage(damage);
        }
    }


    void DropLoot()
    {
        float dropChance = Random.Range(0.0f, 100.0f);
        

        if (dropChance <= itemDropPercent)
        {
            float randomItem = Random.Range(0, itemsToDrop.Count);
            int itemKey = Mathf.RoundToInt(randomItem);

            Instantiate(itemsToDrop[itemKey], transform.position, Quaternion.Euler(0f, 0f, 0f));

        }

    }

    void CheckDeathCount()
    {
        if (enemyDeathCounter == 20)
        {
            LevelManager.instance.newRound = true;
        }
        else if (enemyDeathCounter == 50)
        {
            LevelManager.instance.newRound = true;
        }
        else if (enemyDeathCounter == 90)
        {
            LevelManager.instance.newRound = true;
        }
        else if (enemyDeathCounter == 140)
        {
            LevelManager.instance.newRound = true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Transform player;
    Rigidbody2D _rb;

    public float damage = 2.0f;

    public float enemyHealth = 100.0f;
    float maxHealth = 100.0f;

    public float speed;
    public float lineOfSite;

    Vector3 direction;
    public Transform deathEffect, deathEffect2, deathEffect3, deathEffect4;

    //public GameObject arrows;
    //public GameObject arrowParent;
    //public float arrowForce = 5f;
    //public float firerate;
    //public float nextShootTime;
    //public float range;

    public Slider healthBar;


    private void Start()
    {
        enemyHealth = maxHealth;
        _rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        if (enemyHealth > 0 && player != null)
        {
            direction = player.transform.position - transform.position;
        }

        healthBar.value = enemyHealth;

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

    

    public void DealDamage(float damage)
    {
        damage = 1f;

        enemyHealth -= damage;
        CheckDeath();

    }

    

    private void CheckDeath()
    {
        if (enemyHealth <= 0)
        {
            var boom = Instantiate(deathEffect, transform.position, transform.rotation);
            var boom2 = Instantiate(deathEffect2, transform.position, transform.rotation);
            var boom3 = Instantiate(deathEffect3, transform.position, transform.rotation);
            var boom4 = Instantiate(deathEffect4, transform.position, transform.rotation);
            Destroy(boom.gameObject, 1);
            Destroy(boom2.gameObject, 2);
            Destroy(boom3.gameObject, 3);
            Destroy(boom4.gameObject, 4);

            

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

    

}

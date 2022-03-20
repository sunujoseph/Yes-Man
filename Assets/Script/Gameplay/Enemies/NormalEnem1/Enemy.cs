using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    private Rigidbody2D rb;

    

    Vector3 direction;

    public float _enemySpeed = 10.0f;
    public float _enemyHP; 
    public float _maxHP= 20.0f; 
    public float _damaged;


  


    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        ResetHealth();
    }

    private void Update()
    {
         direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        direction.Normalize();

        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + (direction * _enemySpeed * Time.deltaTime));
    }

    
    void ResetHealth()
    {
        _enemyHP = _maxHP;
    }

    public void TakeDamage(float damage)
    {
        _enemyHP -= damage;

        CheckIfDead();
        
    }

    public void HealDmg(float heal)
    {
        _enemyHP += heal;

        //Check overheal
        if (_enemyHP >= _maxHP)
        {
            //Cap at max
            _enemyHP = _maxHP;
        }
    }

    void KillEnemy()
    {
       
         Destroy(gameObject);
        
    }

    public bool CheckIfDead()
    {
        //Check if Hp > || = 0 

        if (_enemyHP <= 0.0f)
        {
            KillEnemy();
            return true;
        }

        //Enemy not dead
        return false;
    }

}

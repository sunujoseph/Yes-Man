using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehavior : MonoBehaviour
{
    
    float maxHealth = 20.0f;
    GameObject barrel;



    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    private void CheckDeath()
    {
        if (maxHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void DealDamage(float damage)
    {
        damage = 1;
        maxHealth -= damage;
        Debug.Log("barrel has " + maxHealth + " health left");
        CheckDeath();
        
    }
}

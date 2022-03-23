using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    public float _bulletDamage;

    // Bullet script when the bullet hits an object
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hit");
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        

        if (collision.gameObject.tag == "Enemy")
        {

            collision.gameObject.GetComponent<Enemy>().DealDamage(_bulletDamage);

            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "Barrel")
        {

            collision.gameObject.GetComponent<BarrelBehavior>().DealDamage(_bulletDamage); ;

        }

        Destroy(gameObject);
    }
    

    void Update()
    {
        Destroy(this.gameObject, 2.0f);
    }


}

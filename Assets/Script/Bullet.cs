using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    // Bullet script when the bullet hits an object


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hit");
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }

    void Update()
    {
        Destroy(this.gameObject, 2f);
    }


}

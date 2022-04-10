using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    Rigidbody2D arrowRB;
    public float damage = 10.0f;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {      
        Destroy(gameObject, 4);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            collision.gameObject.GetComponent<PlayerControl>().TakeDamage(damage);

            Destroy(this.gameObject);
        }
    }
}
